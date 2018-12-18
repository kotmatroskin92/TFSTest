﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Drawing;
using TestFramework.Logging;
using System.Text;

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
                log.TestLog.Trace($"Change Window.Size to: {size.Width} width and {size.Height} height.");
                driver.Manage().Window.Size = new Size(configuration.WindowWidth.GetValueOrDefault(size.Width),
                    configuration.WindowHeight.GetValueOrDefault(size.Height));
            }

            return ThreadDriver.Value;
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
            var firefoxOptions = GetFirefoxOptions(configuration);
            return new FirefoxDriver("./", firefoxOptions);
        }

        public static IWebDriver CreateChromeDriver(IConfiguration configuration)
        {
            var chromeOptions = GetChromeOptions(configuration);
            return new ChromeDriver("./", chromeOptions);
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
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.AcceptUntrustedCertificates = true;
            firefoxProfile.SetPreference(CapabilityType.UnexpectedAlertBehavior, "ignore");
            var options = new FirefoxOptions { Profile = firefoxProfile };
            return options;
        }
    }
}
