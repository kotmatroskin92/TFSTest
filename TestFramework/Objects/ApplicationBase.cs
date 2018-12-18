using OpenQA.Selenium;
using System;
using ToyotaSpec.Logging;
using System.Threading;
using System.IO;
using System.Text;
using TestFramework.Utils;

namespace ToyotaSpec.Objects
{
    public class ApplicationBase
    {
        public IWebDriver LazyDriver =>
            _driver.Value ?? (_driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log));
        protected static Configuration Configuration;

        protected ApplicationBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var pathToConfig = PathUtils.GetAbsoluteFilePath($"Configuration\\config.json");
            Configuration = Configuration.ParseConfiguration<Configuration>(File.ReadAllText(pathToConfig));
        }
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        public Log Log => _log ?? new Log();
        private Log _log = new Log();

        protected void ReloadWebDriver()
        {
            Log.TestLog.Warn("Reloading WebDriver.");
            if (_driver != null && _driver.IsValueCreated)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
            }

            _driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log);
            Log.TestLog.Warn("WebDriver reloaded.");
        }

        public void PublishScreenshot(IConfiguration configuration)
        {
            var screenshot = LazyDriver.TakeScreenshot();
            var directory = Path.Combine(PathUtils.GetBaseDir(), configuration.ScreenshotFolder);
            PathUtils.EnsureDirectoryExists(directory);
            var path = Path.Combine(directory, $"_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}
