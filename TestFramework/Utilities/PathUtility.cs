using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TestFramework.Utilities
{
    public static class PathUtility
    {

        private static readonly Dictionary<string, Func<string>> _pathHandlers = new Dictionary<string, Func<string>>
        {
            {"currentDir", () => Path.GetFullPath(@".\")},
            {"projectDir", () => Path.GetFullPath(@"..\..\..\")}
        };

        public static void EnsureDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static string BuildAbsolutePath(string relativeUrl)
        {
            return new Regex(@"\{([\w0-9_]+)\}").Replace(relativeUrl, m => _pathHandlers[m.Groups[1].Value]());
        }
    }
}
