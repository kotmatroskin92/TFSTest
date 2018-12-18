using OpenQA.Selenium;
using System;
using ToyotaSpec.Logging;
using System.Threading;
using System.IO;
using System.Text;

namespace ToyotaSpec.Objects
{
    public class ApplicationBase
    {
        public IWebDriver LazyDriver =>
            _driver.Value ?? (_driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log));
        private static String pathToConfig = Directory.GetFiles(
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
                $"Configuration\\config.json",
                SearchOption.AllDirectories)[0];
        protected static Configuration Configuration;

        protected ApplicationBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
    }
}
