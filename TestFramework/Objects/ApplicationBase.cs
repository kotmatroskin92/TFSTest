using System;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using TestFramework.Logging;
using TestFramework.Utils;

namespace TestFramework.Objects
{
    public class ApplicationBase
    {
        private static readonly string _pathToConfig = PathUtils.GetAbsoluteFilePath($"Configuration\\config.json");
        protected static Configuration Configuration = Configuration.ParseConfiguration<Configuration>(File.ReadAllText(_pathToConfig));

        private readonly Log _log = new Log();
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public Log Log => _log ?? new Log();
        public IWebDriver LazyDriver =>
            _driver.Value ?? (_driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log));

        protected ApplicationBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        
        public void PublishScreenshot(IConfiguration configuration)
        {
            var screenshot = LazyDriver.TakeScreenshot();
            var directory = PathUtils.BuildAbsolutePath(configuration.ScreenshotFolder);
            PathUtils.EnsureDirectoryExists(directory);
            var path = Path.Combine(directory, $"_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}
