using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Forms;

namespace HKModWizard.ModDependenciesCommand
{
    public partial class ManageModDependenciesForm : Form
    {
        private readonly List<ModDependencyLineItem> modDeps;
        private readonly ErrorListProvider errorListProvider;
        private readonly IVsHierarchy projectHierarchy;
        private readonly string itemPath;

        public IEnumerable<(bool enable, ModReference reference)> ReferenceActions => referenceList.Items.OfType<ListViewItem>()
            .Where(item => item.Tag is ModReference)
            .Select(item => (item.Checked, item.Tag as ModReference));

        public IEnumerable<ModDependencyLineItem> ModDependencies => modDeps.ToImmutableList();

        public ManageModDependenciesForm(IEnumerable<ModReference> availableMods, 
            IEnumerable<ModReference> referencedMods, 
            IEnumerable<ModDependencyLineItem> modDeps,
            ErrorListProvider errorListProvider,
            IVsHierarchy projectHierarchy,
            string itemPath)
        {
            InitializeComponent();

            this.modDeps = modDeps.ToList();
            this.errorListProvider = errorListProvider;
            this.projectHierarchy = projectHierarchy;
            this.itemPath = itemPath;

            // this is a comprehensive list of all available mod references. therefore we don't need a separate store of it.
            referenceList.Items.AddRange(availableMods.Select(reference =>
            {
                ModReference intersect = referencedMods.Where(r => r == reference).FirstOrDefault();
                ListViewItem item = new ListViewItem(new string[] { reference.ModFolderName, reference.ModDllName })
                {
                    Checked = intersect != null,
                    Tag = intersect ?? reference
                };
                return item;
            }).ToArray());

            modDepsList.Items.AddRange(modDeps.Where(line => !line.IsComment).Select(line =>
            {
                ListViewItem item = new ListViewItem(new string[] { line.ModName, line.ModAlias, line.DirectLink })
                {
                    Tag = line
                };
                return item;
            })
            .ToArray());
        }

        protected override void WndProc(ref Message m)
        {
            // WM_PAINT
            if (m.Msg == 0xf)
            {
                referenceList.Columns[referenceList.Columns.Count - 1].Width = -2;
                modDepsList.Columns[modDepsList.Columns.Count - 1].Width = -2;
            }

            base.WndProc(ref m);
        }

        private bool MatchReferenceToName(ModDependencyLineItem dep, string modName)
        {
            return dep.ModAlias == modName || (dep.ModAlias == null && dep.ModName == modName);
        }

        private string GetFolderName(ModDependencyLineItem dep)
        {
            if (dep.ModAlias != null)
            {
                return dep.ModAlias;
            }
            return dep.ModName;
        }

        private ErrorTask MakeWarning(string msg, int line)
        {
            ErrorTask task = new ErrorTask()
            {
                ErrorCategory = TaskErrorCategory.Warning,
                Category = TaskCategory.All,
                Text = msg,
                Document = itemPath,
                Line = line,
                Column = 0,
                HierarchyItem = projectHierarchy,
            };

            task.Navigate += (sender, e) =>
            {
                // this is apparently a long-standing bug in navigate that will never be fixed because everybody is using this workaround now
                task.Line++;
                errorListProvider.Navigate(task, new Guid(EnvDTE.Constants.vsViewKindCode));
                task.Line--;
            };

            return task;
        }

        private void EnsureModDependency(string inferredModName)
        {
            // see if modDeps has this, add it if not
            bool found = modDeps.Any(dep => MatchReferenceToName(dep, inferredModName));
            if (!found)
            {
                // it's possibly desirable to prompt to see if this is an alias -- but it's probably also fine to just say "hey go edit it yourself"
                // since needing aliases pretty uncommon
                ModDependencyLineItem item = new ModDependencyLineItem() { ModName = inferredModName };
                modDeps.Add(item);
                modDepsList.Items.Add(new ListViewItem(inferredModName) { Tag = item });
            }
        }

        private void ReferenceListSelectionWillChange(object sender, ItemCheckEventArgs e)
        {
            ModReference reference = referenceList.Items[e.Index].Tag as ModReference;
            string inferredModName = reference.ModFolderName;
            if (reference == null)
            {
                return;
            }

            if (e.NewValue == CheckState.Checked)
            {
                // see if modDeps has this, add it if not
                EnsureModDependency(inferredModName);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                IEnumerable<ListViewItem> checkedSharedItems = referenceList.Items.OfType<ListViewItem>()
                    .Where(item => item.Checked && item.Tag is ModReference mr && mr.ModFolderName == inferredModName);
                bool isLast = checkedSharedItems.Count() == 1 && checkedSharedItems.First() == referenceList.Items[e.Index];
                IEnumerable<ListViewItem> found = modDepsList.Items.OfType<ListViewItem>()
                    .Where(item => item.Tag is ModDependencyLineItem dep && MatchReferenceToName(dep, inferredModName));
                if (isLast && found.Count() > 0)
                {
                    foreach (ListViewItem item in found)
                    {
                        modDepsList.Items.Remove(item);
                        modDeps.Remove(item.Tag as ModDependencyLineItem);
                    }
                }
            }
        }

        private void OnReady(object sender, EventArgs e)
        {
            // only start doing this once the form is actually loaded and ready
            referenceList.ItemCheck += ReferenceListSelectionWillChange;
        }

        private void CheckErrors(object sender, EventArgs e)
        {
            errorListProvider.Tasks.Clear();

            // check for existing aliases pointing to things that aren't installed
            foreach (ListViewItem item in modDepsList.Items)
            {
                if (item.Tag is ModDependencyLineItem dep)
                {
                    IEnumerable<ListViewItem> refs = referenceList.Items.OfType<ListViewItem>()
                        .Where(i => i.Tag is ModReference r && r.ModFolderName == GetFolderName(dep));
                    if (!refs.Any())
                    {
                        string warning = $"The dependency on '{dep.ModName}' does not match any installed mods. " +
                                $"Your local alias may be incorrect, or the mod may not be installed at all.";
                        errorListProvider.Tasks.Add(MakeWarning(warning, modDeps.IndexOf(dep)));
                    }
                }
            }

            // check mod deps for duplicate keys; this will cause undefined behavior in the action. issue warnings later
            IEnumerable<IGrouping<string, ModDependencyLineItem>> duplicateGroups = modDeps.Where(dep => !dep.IsComment)
                .GroupBy(dep => dep.ModName).Where(g => g.Count() > 1);
            foreach (IGrouping<string, ModDependencyLineItem> group in duplicateGroups)
            {
                IEnumerable<int> lineNums = group.Select(dep => modDeps.IndexOf(dep)).OrderBy(i => i);
                string warning = $"You have multiple dependencies on '{group.Key}'. This will cause unpredictable " +
                    $"behavior using the GitHub action.";
                foreach (int i in lineNums)
                {
                    errorListProvider.Tasks.Add(MakeWarning(warning, i));
                }
            }

            if (errorListProvider.Tasks.Count > 0)
            {
                MessageBox.Show(this, "Found some potential issues. Once your changes are saved, check the error list for details. " +
                    "You can clear the error list from this dialog once they are fixed.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(this, "No issues remaining!", "No Warnings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FixInconsistencies(object sender, EventArgs e)
        {
            // step 1 - look at our existing references. If mod deps is missing it, add it automatically
            foreach (ListViewItem item in referenceList.Items)
            {
                if (item.Checked && item.Tag is ModReference r)
                {
                    EnsureModDependency(r.ModFolderName);
                }
            }

            // step 2 - look at our existing mod deps. If no selected reference matches, and any unselected references match, select them.
            foreach (ListViewItem item in modDepsList.Items)
            {
                if (item.Tag is ModDependencyLineItem dep)
                {
                    IEnumerable<ListViewItem> refs = referenceList.Items.OfType<ListViewItem>()
                        .Where(i => i.Tag is ModReference r && r.ModFolderName == GetFolderName(dep));
                    if (refs.Any())
                    {
                        // if some are checked already, don't go check the others - it's assumed we probably don't want them.
                        if (!refs.Any(r => r.Checked))
                        {
                            foreach (ListViewItem r in refs)
                            {
                                r.Checked = true;
                            }
                        }
                    }
                }
            }

            // step 3 - check for errors
            CheckErrors(sender, e);
        }
    }
}
