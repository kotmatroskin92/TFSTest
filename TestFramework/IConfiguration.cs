using System;

namespace TestFramework
{
    public interface IConfiguration
    {
        TimeSpan DefaultWaitTimeout { get; }

        Browser Browser { get; }

        bool IsHeadless { get; set; }

        int? WindowHeight { get; set; }

        int? WindowWidth { get; set; }

        bool MaximizeWindow { get; set; }

        string StartPageUrl { get; set; }

        string ScreenshotFolder { get; set; }
    }
}
