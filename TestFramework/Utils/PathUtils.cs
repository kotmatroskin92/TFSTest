using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Utils
{
    public static class PathUtils
    {
        public static string GetAbsoluteFilePath(string path)
        {
            var absolutePath = Directory.GetFiles(
                Directory.GetParent(GetBaseDir()).Parent.Parent.Parent.FullName,
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
