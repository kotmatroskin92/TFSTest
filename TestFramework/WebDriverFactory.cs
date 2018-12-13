using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Drawing;
using TestFramework.Logging;

namespace TestFramework
{
    class WebDriverFactory
    {

        private static readonly ThreadLocal<IWebDriver> ThreadDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver CreateWebDriver(IConfiguration configuration, Log log)
        {
            log.TestLog.Trace("Choosed browser from config: " + configuration.Browser);
            var driver = ResolveLocalDriver(configuration);

            ThreadDriver.Value = driver;

            if (configuration.MaximizeWindow)
            {
                driver.Manage().Window.Maximize();
            }
            else
            {
                var size = driver.Manage().Window.Size;
                log.TestLog.Trace($"Window.Size: {size.Width} width and {size.Height} height. Size is changing");
                driver.Manage().Window.Size = new Size(configuration.WindowWidth.GetValueOrDefault(size.Width),
                    configuration.WindowHeight.GetValueOrDefault(size.Height));
            }

            LogWebdriverInfo(driver, log);
            return ThreadDriver.Value;
        }

        public static void LogWebdriverInfo(IWebDriver driver, Log log)
        {
            var cap = ((RemoteWebDriver)driver).Capabilities;
            var browserName = cap.GetCapability("browserName");
            log.TestLog.Trace("Webdriver browser name: " + browserName);
            log.TestLog.Trace("Browser size: " + driver.Manage().Window.Size);
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

        public static IWebDriver CreateFirefoxDriver(IConfiguration configuration)
        {
            var firefoxProfile = GetFirefoxOptions(configuration);
            return new FirefoxDriver(firefoxProfile);
        }

        public static IWebDriver CreateChromeDriver(IConfiguration configuration)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.SuppressInitialDiagnosticInformation = true;
            chromeDriverService.EnableVerboseLogging = false;
            var options = GetChromeOptions(configuration);
            var chromeDriver = new ChromeDriver(chromeDriverService, options, configuration.DefaultCommandTimeout);
            return chromeDriver;
        }

        private static ChromeOptions GetChromeOptions(IConfiguration environmentConfig)
        {
            var chromeOptions = new ChromeOptions();

            if (environmentConfig.IsHeadless)
            {
                chromeOptions.AddArgument("--headless");
            }
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            return chromeOptions;
        }

        private static FirefoxOptions GetFirefoxOptions(IConfiguration configuration)
        {
            var options = new FirefoxOptions();
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.AcceptUntrustedCertificates = true;
            firefoxProfile.SetPreference("profile.accept_untrusted_certs", true);
            firefoxProfile.SetPreference("dom.successive_dialog_time_limit", 0);
            firefoxProfile.SetPreference(CapabilityType.UnexpectedAlertBehavior, "ignore");
            options.Profile = firefoxProfile;
            return options;
        }
    }
}
