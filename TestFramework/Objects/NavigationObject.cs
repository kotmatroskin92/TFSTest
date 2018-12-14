using TestFramework.Logging;
using System;
using OpenQA.Selenium;

namespace TestFramework.Objects
{
    public static class NavigationObject
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
    }
}
