using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TestFramework.Utils
{
    public static class PathUtils
    {

        private static readonly Dictionary<string, Func<string>> pathHandlers = new Dictionary<string, Func<string>>
        {
            {"currentDir", () => AppDomain.CurrentDomain.BaseDirectory}
        };

        public static string GetAbsoluteFilePath(string path)
        {
            var directory = Directory.GetParent(GetBaseDir()).Parent;
            var absolutePath = Directory.GetFiles(
                directory?.Parent?.Parent?.FullName ?? throw new InvalidOperationException(),
                path,
                SearchOption.AllDirectories)[0];

            return absolutePath;
        }

        public static void EnsureDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static string GetBaseDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string BuildAbsolutePath(string relativeUrl)
        {
            return new Regex(@"\{([\w0-9_]+)\}").Replace(relativeUrl, m => pathHandlers[m.Groups[1].Value]());
        }
    }
}
