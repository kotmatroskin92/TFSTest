using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.TransientFaultHandling;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Elements
{
    public abstract class ElementFinder : ApplicationBase, ITransientErrorDetectionStrategy
    {
        private readonly RetryStrategy _simpleStrategy = new Incremental(3, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        protected IWebDriver Driver => LazyDriver;

        public bool IsTransient(Exception ex)
        {
            return ex is StaleElementReferenceException;
        }

        protected IWebElement WaitForElement(By targetElementLocator)
        {
            return InternalFinder(targetElementLocator);
        }

        protected IReadOnlyCollection<IWebElement> FindChildren(By parentLocator, By childLocator)
        {
            return WaitForElement(parentLocator).FindElements(childLocator);
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By targetElementLocator, By parentElementLocator = null)
        {
            if (parentElementLocator != null)
            {
                return new RetryPolicy(this, _simpleStrategy).ExecuteAction(() => new ReadOnlyCollection<IWebElement>(
                    FindChildren(parentElementLocator, targetElementLocator).Where(el => el.Displayed && el.Enabled).ToList()));
            }

            return new RetryPolicy(this, _simpleStrategy).ExecuteAction(() => new ReadOnlyCollection<IWebElement>(
                Driver.FindElements(targetElementLocator).Where(el => el.Displayed && el.Enabled).ToList()));
        }

        protected bool IsVisible (By targetElementLocator)
        {
            try
            {
                InternalFinder(targetElementLocator);

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

            protected IWebElement InternalFinder (By targetElementLocator)
        {
            try
                {
                    Log.TestLog.Info($"Wait element: {targetElementLocator}");
                    return new WebDriverWait(Driver, Configuration.DefaultWaitTimeout)
                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(targetElementLocator));
                }
                catch (WebDriverTimeoutException)
                {
                    throw new Exception($"WebDriverTimeoutException: Element {targetElementLocator} was not found for {Configuration.DefaultWaitTimeout}");
                }
        }
    }
}
