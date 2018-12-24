using System;
using OpenQA.Selenium;
using TestFramework.Logging;

namespace TestFramework.WebDriver
{
    public static class BrowserExtensions
    {

        public static Log Log = new Log();

        public static string GetCurrentUrl(this IWebDriver webDriver)
        {
            return webDriver.Url;
        }

        public static void NavigateTo(this IWebDriver webDriver, string url)
        {
            var newUrl = new Uri(url);
            NavigateTo(webDriver, newUrl);
        }

        public static Screenshot TakeScreenshot(this IWebDriver driver)
        {
            return ((ITakesScreenshot)driver).GetScreenshot();
        }

        private static void NavigateTo(IWebDriver webDriver, Uri url)
        {
            if (webDriver.Url != url.ToString())
            {
                Log.TestLog.Info($"Navigate to URL: {url}");
                webDriver.Navigate().GoToUrl(url);
            }
        }
    }
}
