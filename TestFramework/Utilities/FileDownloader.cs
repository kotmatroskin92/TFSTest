using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace TestFramework.Utilities
{
    public class FileDownloader : ApplicationBase
    {
        private static readonly string[] _tempFileParts = { "part", "crdownload" };
        private static readonly string _directory = Configuration.DownloadsFolder;

        public static bool Exists(string fileNamePattern)
        {
            if (!Directory.Exists(_directory))
            {
                return false;
            }

            return Directory.GetFiles(_directory, fileNamePattern).Any();
        }

        public static bool IsFileDownloadingInProgress(string fileNamePattern)
        {
            if (!Directory.Exists(_directory))
            {
                return true;
            }

            return Directory.GetFiles(_directory, fileNamePattern).Any(file =>
            {
                var lastFileNamePrefix = file.Split('.').LastOrDefault();

                return _tempFileParts.Any(tempExtension => tempExtension.Equals(lastFileNamePrefix));
            });
        }

        public static string[] WaitForDownload(string fileNamePattern)
        {
            return WaitForDownload(fileNamePattern, Configuration.DefaultWaitTimeout);
        }

        public static string[] WaitForDownload(string fileNamePattern, TimeSpan waitTime)
        {
            const int sleepTime = 200;

            for (var time = 0; !Exists(fileNamePattern) || IsFileDownloadingInProgress(fileNamePattern); time += sleepTime)
            {
                if (time > waitTime.TotalMilliseconds)
                {
                    throw new TimeoutException(
                        $"File with name pattern '{fileNamePattern}' not found. {GetAdditionInfo()}");
                }
                Thread.Sleep(sleepTime);
            }

            return Directory.GetFiles(_directory, fileNamePattern);
        }

        private static string GetAdditionInfo()
        {
            if (!Directory.Exists(_directory))
            {
                return "Download directory not found";
            }
            var fileNames = Directory.GetFiles(_directory).Select(Path.GetFileName);

            return $"Files in download directory:\r\n{string.Join("\r\n", fileNames)}";
        }

        public static void ClearDir()
        {
            if (Directory.Exists(_directory))
            {
                Directory.Delete(_directory, true);
            }
        }
    }
}
