﻿using Microsoft.Build.Evaluation;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HKModWizard
{
    internal class ModReference
    {
        private static readonly Regex modDepMatcher = new Regex(@"^\$\(HollowKnightRefs\)[\\/]Mods[\\/](?<Folder>.*)[\\/](?<ModName>.*\.dll)$");

        public ProjectItem ProjectItem { get; private set; }

        public string HintPath { get; private set; }

        public string ModFolderName { get; private set; }

        public string ModDllName { get; private set; }

        private ModReference(ProjectItem item, string hintPath, string folderName, string dllName)
        {
            ProjectItem = item;
            HintPath = hintPath;
            ModFolderName = folderName;
            ModDllName = dllName;
        }

        public static ModReference Parse(ProjectItem item)
        {
            ProjectMetadata hint = item.GetMetadata("HintPath");
            if (hint != null)
            {
                string hintPath = hint.UnevaluatedValue;
                Match m = modDepMatcher.Match(hintPath);
                if (m.Success)
                {
                    string folder = m.Groups["Folder"].Value;
                    string mod = m.Groups["ModName"].Value;
                    return new ModReference(item, hintPath, folder, mod);
                }
            }
            return null;
        }

        public static ModReference AddToProject(Project project, string folderName, string modFileName)
        {
            if (project != null)
            {
                string hintPath = $"$(HollowKnightRefs)/Mods/{folderName}/{modFileName}";
                ProjectItem addedItem = project.AddItem("Reference", modFileName.Replace(".dll", ""), new Dictionary<string, string>
                {
                    ["HintPath"] = hintPath
                }).First();
                return new ModReference(addedItem, hintPath, folderName, modFileName);
            }
            return null;
        }
    }
}