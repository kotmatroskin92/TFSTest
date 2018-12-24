using System;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using TestFramework.Logging;
using TestFramework.Utilities;
using TestFramework.WebDriver;

namespace TestFramework
{
    public class ApplicationBase
    {
        private const string _configurationDir = @"Configuration\config.json";
        private static readonly string _pathToConfig = PathUtility.GetAbsoluteFilePath(_configurationDir);
        private static readonly Log _log = new Log();
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        protected static Configuration Configuration = Configuration.ParseConfiguration<Configuration>(File.ReadAllText(_pathToConfig));

        public static Log Log => _log ?? new Log();
        public IWebDriver LazyDriver =>
            _driver.Value ?? (_driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log));

        protected ApplicationBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        
        public void PublishScreenshot(IConfiguration configuration)
        {
            var screenshot = LazyDriver.TakeScreenshot();
            var directory = PathUtility.BuildAbsolutePath(configuration.ScreenshotFolder);
            PathUtility.EnsureDirectoryExists(directory);
            var path = Path.Combine(directory, $"_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }

        public void QuitWebDriver()
        {
            if (_driver.Value != null)
            {
                Log.TestLog.Info("Quit browser");
                _driver.Value.Quit();
                _driver.Value.Dispose();
                _driver.Value = null;
            }
        }
    }
}
