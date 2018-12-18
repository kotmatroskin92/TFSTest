using System;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TestFramework.Logging;

namespace TestFramework
{
    class WebDriverFactory
    {

        private static readonly ThreadLocal<IWebDriver> _threadDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver CreateWebDriver(IConfiguration configuration, Log log)
        {
            log.TestLog.Trace("Choosed browser from config: " + configuration.Browser);
            var driver = ResolveLocalDriver(configuration);

            _threadDriver.Value = driver;

            if (configuration.MaximizeWindow)
            {
                driver.Manage().Window.Maximize();
            }
            else
            {
                var size = driver.Manage().Window.Size;
                log.TestLog.Trace($"Change Window.Size to: {size.Width} width and {size.Height} height.");
                driver.Manage().Window.Size = new Size(configuration.WindowWidth.GetValueOrDefault(size.Width),
                    configuration.WindowHeight.GetValueOrDefault(size.Height));
            }

            return _threadDriver.Value;
        }

        public static IWebDriver CreateFirefoxDriver(IConfiguration configuration)
        {
            var firefoxOptions = GetFirefoxOptions(configuration);

            return new FirefoxDriver("./", firefoxOptions);
        }

        public static IWebDriver CreateChromeDriver(IConfiguration configuration)
        {
            var chromeOptions = GetChromeOptions(configuration);

            return new ChromeDriver("./", chromeOptions);
        }

        private static IWebDriver ResolveLocalDriver(IConfiguration configuration)
        {
            IWebDriver driver;
            switch (configuration.Browser)
            {
                case Browser.Firefox:
                    driver = CreateFirefoxDriver(configuration);
                    break;

                case Browser.Chrome:
                    driver = CreateChromeDriver(configuration);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Browser {configuration.Browser} is not supported");
            }

            return driver;
        }

        private static ChromeOptions GetChromeOptions(IConfiguration environmentConfig)
        {
            var chromeOptions = new ChromeOptions();

            if (environmentConfig.IsHeadless)
            {
                chromeOptions.AddArgument("--headless");
            }
            chromeOptions.AddArgument("--disable-popup-blocking");

            return chromeOptions;
        }

        private static FirefoxOptions GetFirefoxOptions(IConfiguration configuration)
        {
            var firefoxProfile = new FirefoxProfile {AcceptUntrustedCertificates = true};
            firefoxProfile.SetPreference(CapabilityType.UnexpectedAlertBehavior, "ignore");
            var options = new FirefoxOptions { Profile = firefoxProfile };

            return options;
        }
    }
}
