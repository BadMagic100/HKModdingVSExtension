using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKModWizard
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
            LocalOverridesSetupForm input = new LocalOverridesSetupForm();
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
