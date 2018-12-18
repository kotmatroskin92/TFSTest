using System;
using System.IO;

namespace TestFramework.Utils
{
    public static class PathUtils
    {
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
    }
}
