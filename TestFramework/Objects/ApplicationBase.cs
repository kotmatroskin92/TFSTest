using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Logging;
using System.Threading;
using BoDi;

namespace TestFramework.Objects
{
    public abstract class ApplicationBase
    {
        public ObjectContainer Container { get; }

        public IWebDriver LazyDriver =>
            _driver.Value ?? (_driver.Value = WebDriverFactory.CreateWebDriver(Configuration, Log));
        public IConfiguration Configuration => Container.Resolve<IConfiguration>();
        private readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        public Log Log => _log ?? new Log();
        private Log _log = new Log();

        protected ApplicationBase(ObjectContainer container)
        {
            Container = container;
        }

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
