using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestFramework.Logging;
using System.Threading;
using BoDi;
using System.IO;

namespace TestFramework.Objects
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
            Configuration = Configuration.ParseConfiguration<Configuration>(File.ReadAllText(pathToConfig));
        }
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        public Log Log => _log ?? new Log();
        private Log _log = new Log();

        public void DeleteAllCookies()
        {
            _driver.Value.Manage().Cookies.DeleteAllCookies();
        }

        public void DeleteCookies(string[] excludeCookies)
        {
            foreach (var cookie in _driver.Value.Manage().Cookies.AllCookies)
            {
                if (!excludeCookies.Contains(cookie.Name))
                {
                    _driver.Value.Manage().Cookies.DeleteCookie(cookie);
                }
            }
        }

        public void ReloadWebDriver()
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

        public bool IsDriverValueCreated()
        {
            return _driver.IsValueCreated;
        }
    }
}
