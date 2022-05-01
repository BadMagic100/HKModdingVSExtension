using Microsoft.Build.Evaluation;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using VSLangProj;
using DTEItem = EnvDTE.ProjectItem;
using DTEProj = EnvDTE.Project;
using MSBProj = Microsoft.Build.Evaluation.Project;
using Task = System.Threading.Tasks.Task;

namespace HKModWizard
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ManageModDependenciesCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("8744a882-c743-48de-ae71-08540bcdf7f8");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        private readonly IMenuCommandService commandService;
        private readonly IVsMonitorSelection monitorSelection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageModDependenciesCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private ManageModDependenciesCommand(AsyncPackage package, IMenuCommandService commandService, IVsMonitorSelection monitorSelection)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.monitorSelection = monitorSelection ?? throw new ArgumentNullException(nameof(monitorSelection));

            CommandID menuCommandID = new CommandID(CommandSet, CommandId);
            OleMenuCommand menuItem = new OleMenuCommand(Execute, menuCommandID);
            // this is needed to let VS handle visibility via constraints
            menuItem.Supported = false;

            commandService.AddCommand(menuItem);
        }

        private DTEProj GetSelectedProject()
        {
            IntPtr hier = IntPtr.Zero;
            IntPtr container = IntPtr.Zero;
            uint itemId;

            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                IVsMultiItemSelect mis = null;
                ErrorHandler.ThrowOnFailure(monitorSelection.GetCurrentSelection(out hier, out itemId, out mis, out container));

                if (itemId != VSConstants.VSITEMID_NIL && // an item is selected and...
                    hier != IntPtr.Zero) // we have a pointer to a single hierarchy
                {
                    IVsHierarchy hierarchy = Marshal.GetObjectForIUnknown(hier) as IVsHierarchy;
                    hierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out object projRaw);

                    return projRaw as DTEProj;
                }
            }
            finally
            {
                if (hier != IntPtr.Zero)
                {
                    Marshal.Release(hier);
                }
                if (container != IntPtr.Zero)
                {
                    Marshal.Release(container);
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ManageModDependenciesCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in ManageModDependenciesCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            IMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as IMenuCommandService;
            IVsMonitorSelection monitorSelection = await package.GetServiceAsync(typeof(IVsMonitorSelection)) as IVsMonitorSelection;

            Instance = new ManageModDependenciesCommand(package, commandService, monitorSelection);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            DTEProj proj = GetSelectedProject();

            if (proj != null)
            {
                DTEItem item = proj.ProjectItems.Item("ModDependencies.txt");
                IEnumerable<ModDependencyLineItem> existingModDependencies = Enumerable.Empty<ModDependencyLineItem>();
                if (item != null)
                {
                    using (StreamReader sr = File.OpenText(item.FileNames[0]))
                    {
                        existingModDependencies = sr.ReadToEnd().Split('\n').Select(s => ModDependencyLineItem.Parse(s));
                    }
                }

                VSProject vsp = proj.Object as VSProject;
                MSBProj msBuildProj = new MSBProj(vsp.Project.FullName);
                string hkRefs = msBuildProj.GetPropertyValue("HollowKnightRefs");

                // todo - pass these to a dialog for handling. the dialog will be responsible for:
                //   * detecting currently installed mods from HollowKnightRefs (maybe the command ought to do this as well?)
                //   * detecting which of these are referenced already (things that have the same hintpath probably? include tag? folder name?)
                //   * select new items to be referenced
                IEnumerable<ModReference> existingModReferences = msBuildProj.GetItems("Reference")
                    .Select(x => ModReference.Parse(x))
                    .Where(x => x != null);

                // todo - add requested new items from dialog (from modlinks)
                // todo - manage the mods in ModDependencies.txt as well.
                // ModReference cmi = ModReference.AddToProject(msBuildProj, "ConnectionMetadataInjector", "ConnectionMetadataInjector.dll");
                // todo - save only if dialogresult is ok
                // todo - add ModDependencies.txt as a projectitem if item is null
                msBuildProj.Save();

                ProjectCollection.GlobalProjectCollection.UnloadAllProjects();
            }
        }
    }
}
