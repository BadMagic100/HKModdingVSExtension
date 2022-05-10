using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HKModWizard.ModDependenciesCommand
{
    public partial class ManageModDependenciesForm : Form
    {
        private readonly List<ModDependencyLineItem> modDeps;

        public ManageModDependenciesForm(IEnumerable<ModReference> availableMods, 
            IEnumerable<ModReference> referencedMods, 
            IEnumerable<ModDependencyLineItem> modDeps)
        {
            InitializeComponent();

            this.modDeps = modDeps.ToList();

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

        private void FixInconsistencies(object sender, EventArgs e)
        {
            List<string> warnings = new List<string>();

            // step 1 - look at our existing references. If mod deps is missing it, add it automatically
            foreach (ListViewItem item in referenceList.Items)
            {
                if (item.Checked && item.Tag is ModReference r)
                {
                    EnsureModDependency(r.ModFolderName);
                }
            }

            // step 2 - look at our existing mod deps. If no selected reference matches, and any unselected references match, select them.
            //   2b - If no available reference matches, issue a warning for later reporting.
            //        Either their local alias is incorrect, they are missing the mod locally, or they should remove the dependency entirely
            foreach (ListViewItem item in modDepsList.Items)
            {
                if (item.Tag is ModDependencyLineItem dep)
                {
                    IEnumerable<ListViewItem> refs = referenceList.Items.OfType<ListViewItem>()
                        .Where(i => i.Tag is ModReference r && r.ModFolderName == GetFolderName(dep));
                    if (refs.Any())
                    {
                        foreach (ListViewItem r in refs)
                        {
                            r.Checked = true;
                        }
                    }
                    else
                    {
                        warnings.Add($"The dependency on '{dep.ModName}' (line {modDeps.IndexOf(dep) + 1}) does not match any installed mods. " +
                            $"Your local alias may be incorrect, or the mod may not be installed at all.");
                    }
                }
            }

            // step 3 - check mod deps for duplicate keys; this will cause undefined behavior in the action. issue warnings later
            IEnumerable<IGrouping<string, ModDependencyLineItem>> duplicateGroups = modDeps.Where(dep => !dep.IsComment)
                .GroupBy(dep => dep.ModName).Where(g => g.Count() > 1);
            foreach (IGrouping<string, ModDependencyLineItem> group in duplicateGroups)
            {
                IEnumerable<int> lineNums = group.Select(dep => modDeps.IndexOf(dep)).OrderBy(i => i);
                warnings.Add($"You have multiple dependencies on '{group.Key}' (lines {string.Join(", ", lineNums)}). This will cause unpredictable " +
                    $"behavior using the GitHub action.");
            }

            // step 4 - report warnings
            foreach(string warning in warnings)
            {
                MessageBox.Show(this, warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
