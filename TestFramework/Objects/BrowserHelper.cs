using ToyotaSpec.Logging;
using System;
using OpenQA.Selenium;

namespace ToyotaSpec.Objects
{
    public static class BrowserHelper
    {

        public static Log Log = new Log();

        public static string getCurrentUrl(this IWebDriver webDriver)
        {
            return webDriver.Url;
        }

        public static void NavigateTo(this IWebDriver webDriver, string url)
        {
            var newUrl = new Uri(url);
            NavigateTo(webDriver, newUrl);
        }

        private static void NavigateTo(IWebDriver webDriver, Uri url)
        {
            if (webDriver.Url != url.ToString())
            {
                Log.TestLog.Info($"Navigate to URL: {url}");
                webDriver.Navigate().GoToUrl(url);
            }
        }

        public static void QuitWebDriver(this IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                Log.TestLog.Info($"Quit browser");
                webDriver.Quit();
                webDriver.Dispose();
            }
        }
    }
}
