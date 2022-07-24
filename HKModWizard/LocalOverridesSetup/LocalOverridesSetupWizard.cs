using EnvDTE;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;

namespace HKModWizard.LocalOverridesSetup
{
    internal class LocalOverridesSetupWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ServiceProvider serviceProvider = new ServiceProvider((IServiceProvider)automationObject);
            WritableSettingsStore settingsStore = new ShellSettingsManager(serviceProvider).GetWritableSettingsStore(SettingsScope.UserSettings);

            LocalOverridesSetupForm input = new LocalOverridesSetupForm(new HKSettings(settingsStore));
            input.ShowDialog();

            replacementsDictionary.Add("$hkmanaged$", input.HollowKnightManagedFolder);
            replacementsDictionary.Add("$localoverrides$", "LocalOverrides");
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
