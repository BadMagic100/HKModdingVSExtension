using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.IO;

namespace HKModWizard
{
    public class SolutionSetupWizard : IWizard
    {
        DTE2 dte;

        string buildYmlTargetPath;
        string readmeTargetPath;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            Solution2 sln = dte.Solution as Solution2;
            // only do additional work if this is the first project in the solution
            if (sln.Projects.Count > 1)
            {
                return;
            }
            
            Project folderProj = sln.AddSolutionFolder("Solution Files");

            ProjectItem readme = sln.FindProjectItem("README.md");
            string readmeCurrentPath = readme.FileNames[0];
            readme.Remove();
            File.Move(readmeCurrentPath, readmeTargetPath);
            folderProj.ProjectItems.AddFromFile(readmeTargetPath);

            ProjectItem buildYml = sln.FindProjectItem("build.yml");
            string buildYmlCurrentPath = buildYml.FileNames[0];
            buildYml.Remove();
            Directory.CreateDirectory(Path.GetDirectoryName(buildYmlTargetPath));
            File.Move(buildYmlCurrentPath, buildYmlTargetPath);
            folderProj.ProjectItems.AddFromFile(buildYmlTargetPath);
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
            dte = (DTE2)automationObject;

            string solutionDir = replacementsDictionary["$solutiondirectory$"];
            buildYmlTargetPath = Path.Combine(solutionDir, ".github", "workflows", "build.yml");
            readmeTargetPath = Path.Combine(solutionDir, "README.md");

            UserInputForm input = new UserInputForm();
            input.ShowDialog();

            replacementsDictionary.Add("$hkmanaged$", input.HollowKnightManagedFolder);
            replacementsDictionary.Add("$usenullableannotations$", input.Nullable ? "enable" : "disable");
            replacementsDictionary.Add("$author$", input.Author);
            replacementsDictionary.Add("$desc$", input.Description);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (filePath == "README.md" || filePath == "build.yml")
            {
                Solution2 sln = dte.Solution as Solution2;
                // only do additional work if this is the first project in the solution
                return sln.Projects.Count == 0;
            }
            else
            {
                return true;
            }
        }
    }
}
