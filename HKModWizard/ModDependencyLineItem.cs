using System.Collections.Generic;

namespace HKModWizard
{
    internal class ModDependencyLineItem
    {
        private const string TOKEN_AS = "as";
        private const string TOKEN_FROM = "from";

        public string ModName { get; set; }
        public string ModAlias { get; set; }
        public string DirectLink { get; set; }
        public string Comment { get; set; }

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
    }
}
