using System;
using System.Threading;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using ToyotaSpec.Logging;
using TestFramework.Utils;

namespace ToyotaSpec.Objects
{
    public class ApplicationBase
    {
        protected static Configuration Configuration;
        private readonly Log _log = new Log();
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public Log Log => _log ?? new Log();
        public IWebDriver LazyDriver =>
            _driver.Value ?? (_driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log));

        protected ApplicationBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var pathToConfig = PathUtils.GetAbsoluteFilePath($"Configuration\\config.json");
            Configuration = Configuration.ParseConfiguration<Configuration>(File.ReadAllText(pathToConfig));
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
