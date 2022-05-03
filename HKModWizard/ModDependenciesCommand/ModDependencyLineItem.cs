using System;
using System.Collections.Generic;

namespace HKModWizard.ModDependenciesCommand
{
    public class ModDependencyLineItem : IEquatable<ModDependencyLineItem>
    {
        private const string TOKEN_AS = "as";
        private const string TOKEN_FROM = "from";

        public string ModName { get; set; }
        public string ModAlias { get; set; }
        public string DirectLink { get; set; }
        public string Comment { get; set; }

        public bool IsComment
        {
            get
            {
                return !string.IsNullOrEmpty(Comment)
                    && string.IsNullOrEmpty(ModName)
                    && string.IsNullOrEmpty(ModAlias)
                    && string.IsNullOrEmpty(DirectLink);
            }
        }

        public override string ToString()
        {
            string result = "" + ModName;
            if (!string.IsNullOrEmpty(ModAlias))
            {
                result += $" {TOKEN_AS} {ModAlias}";
            }
            if (!string.IsNullOrEmpty(DirectLink))
            {
                result += $" {TOKEN_FROM} {DirectLink}";
            }
            if (!string.IsNullOrEmpty(Comment))
            {
                result += $" {Comment}";
            }
            return result.Trim();
        }

        public static ModDependencyLineItem Parse(string line)
        {
            line = line.Trim();

            Dictionary<string, string> parts = new Dictionary<string, string>();
            string curField = nameof(ModName);
            string buffer = "";
            string[] tokens = line.Split(' ');
            foreach (string token in tokens)
            {
                if (token.StartsWith("#"))
                {
                    if (buffer != "")
                    {
                        parts[curField] = buffer;
                        buffer = "";
                    }
                    curField = nameof(Comment);
                }
                bool isComment = curField == nameof(Comment);
                
                if (!isComment && token == TOKEN_AS)
                {
                    if (curField == nameof(ModName))
                    {
                        parts[curField] = buffer;
                        buffer = "";
                        curField = nameof(ModAlias);
                    }
                    else
                    {
                        // fail parsing gracefully, treat content as a comment so we can reprint and keep order, but don't try to process
                        // it in a useful way
                        return new ModDependencyLineItem()
                        {
                            Comment = line
                        };
                    }
                }
                else if (!isComment && token == TOKEN_FROM)
                {
                    parts[curField] = buffer;
                    buffer = "";
                    curField = nameof(DirectLink);
                }
                else
                {
                    if (buffer != "")
                    {
                        buffer += " ";
                    }
                    buffer += token;
                }
            }
            // ran out of tokens, push the buffer into whatever the current field is - assuming it's meaninful content
            if (buffer != "")
            {
                parts[curField] = buffer;
            }
            // build the dependency from fields we parsed
            ModDependencyLineItem result = new ModDependencyLineItem();
            if (parts.TryGetValue(nameof(ModName), out string modName))
            {
                result.ModName = modName;
            }
            if (parts.TryGetValue(nameof(ModAlias), out string modAlias))
            {
                result.ModAlias = modAlias;
            }
            if (parts.TryGetValue(nameof(DirectLink), out string directLink))
            {
                result.DirectLink = directLink;
            }
            if (parts.TryGetValue(nameof(Comment), out string comment))
            {
                result.Comment = comment;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModDependencyLineItem);
        }

        public bool Equals(ModDependencyLineItem other)
        {
            return other != null &&
                   ModName == other.ModName &&
                   ModAlias == other.ModAlias &&
                   DirectLink == other.DirectLink &&
                   Comment == other.Comment;
        }

        public override int GetHashCode()
        {
            int hashCode = -1120534817;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ModName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ModAlias);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DirectLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Comment);
            return hashCode;
        }

        public static bool operator ==(ModDependencyLineItem left, ModDependencyLineItem right)
        {
            return EqualityComparer<ModDependencyLineItem>.Default.Equals(left, right);
        }

        public static bool operator !=(ModDependencyLineItem left, ModDependencyLineItem right)
        {
            return !(left == right);
        }
    }
}
