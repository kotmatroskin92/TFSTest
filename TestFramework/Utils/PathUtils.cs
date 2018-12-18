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
            return Directory.GetFiles(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
                path, SearchOption.AllDirectories)[0];
        }
    }
}
