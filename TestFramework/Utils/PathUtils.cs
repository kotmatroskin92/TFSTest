using System;
using System.IO;

namespace TestFramework.Utils
{
    public static class PathUtils
    {
        public static string GetAbsoluteFilePath(string path)
        {
            try
            {
                var directory = Directory.GetParent(GetBaseDir()).Parent;
                var absolutePath = Directory.GetFiles(
                    directory.Parent.Parent.FullName,
                    path,
                    SearchOption.AllDirectories)[0];
                return absolutePath;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException($"File {path} not found. {e}");
            }
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
