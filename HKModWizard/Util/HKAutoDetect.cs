using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace HKModWizard.Util
{
    // heavily referenced from Scarab installer. I have removed nullable annotations (because they're not supported in this template's language
    // version) and extracted PathUtil.ValidateWithSuffix to the FindManaged method.
    internal static class HKAutoDetect
    {
        private static readonly ImmutableList<string> STATIC_PATHS = new List<string>
        {
            "Program Files/Steam/steamapps/common/Hollow Knight",
            "Program Files (x86)/Steam/steamapps/common/Hollow Knight",
            "Program Files/GOG Galaxy/Games/Hollow Knight",
            "Program Files (x86)/GOG Galaxy/Games/Hollow Knight",
            "Steam/steamapps/common/Hollow Knight",
            "GOG Galaxy/Games/Hollow Knight"
        }
        .SelectMany(path => DriveInfo.GetDrives().Select(d => Path.Combine(d.Name, path))).ToImmutableList();

        private static readonly ImmutableList<string> USER_SUFFIX_PATHS = new List<string>
        {
            ".local/.share/Steam/steamapps/common/Hollow Knight",
            "Library/Application Support/Steam/steamapps/common/Hollow Knight/hollow_knight.app"
        }
        .ToImmutableList();

        public static bool TryAutoDetectPath(out string path)
        {
            return TryAutoDetectFromStaticInstall(out path) || TryDetectFromUserHome(out path) || TryDetectFromRegistry(out path);
        }

        private static bool TryAutoDetectFromStaticInstall(out string path)
        {
            path = STATIC_PATHS
                .Select(root => FindManaged(root))
                .FirstOrDefault(root => root != null);
            return path != null;
        }

        private static bool TryDetectFromUserHome(out string path)
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            path = USER_SUFFIX_PATHS
                .Select(s => Path.Combine(home, s))
                .Select(root => FindManaged(root))
                .FirstOrDefault(root => root != null);
            return path != null;
        }

        private static bool TryDetectFromRegistry(out string path)
        {
            path = null;
            if(!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return false;
            }

            return TryDetectSteamRegistry(out path) || TryDetectGogRegistry(out path);
        }

        private static bool TryDetectSteamRegistry(out string path)
        {
            path = null;

            string steam_install = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", null) as string;
            if (steam_install == null)
            {
                return false;
            }

            IEnumerable<string> lines;

            try
            {
                lines = File.ReadLines(Path.Combine(steam_install, "steamapps", "libraryfolders.vdf"));
            }
            catch (Exception)
            {
                return false;
            }

            string Parse(string line)
            {
                line = line.TrimStart();

                if (!line.StartsWith("\"path\""))
                {
                    return null;
                }

                string[] pair = line.Split(new char[] { '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);

                return pair.Length != 2
                    ? null
                    : pair[1].Trim('"');
            }

            IEnumerable<string> library_paths = lines.Select(Parse).OfType<string>();

            path = library_paths.Select(library_path => Path.Combine(library_path, "steamapps", "common", "Hollow Knight"))
                                .Select(root => FindManaged(root))
                                .FirstOrDefault(root => root != null);

            return path != null;
        }

        private static bool TryDetectGogRegistry(out string path)
        {
            path = null;

            string gog_path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\GOG.com\Games\1308320804", "workingDir", null) as string;
            if (gog_path == null) 
            {
                return false;
            }

            path = FindManaged(gog_path);
            return path != null;
        }

        private static readonly string[] SUFFIXES =
        {
            // GoG
            "Hollow Knight_Data/Managed",
            // Steam
            "hollow_knight_Data/Managed",
            // Mac
            "Contents/Resources/Data/Managed"
        };

        public static string FindManaged(string root)
        {
            if (!Directory.Exists(root))
            {
                return null;
            }

            string suffix = SUFFIXES.FirstOrDefault(s => Directory.Exists(Path.Combine(root, s)));

            if (suffix is null || !File.Exists(Path.Combine(root, suffix, "Assembly-CSharp.dll")))
            {
                return null;
            }

            return Path.Combine(root, suffix);
        }
    }
}
