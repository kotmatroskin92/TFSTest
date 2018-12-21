using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.TransientFaultHandling;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Objects
{
    public abstract class ElementFinder : ApplicationBase, ITransientErrorDetectionStrategy
    {
        private readonly RetryStrategy _simpleStrategy = new Incremental(4, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(0.5));

        protected IWebDriver Driver => LazyDriver;

        public bool IsTransient(Exception ex)
        {
            return ex is StaleElementReferenceException;
        }

        protected IWebElement WaitForElement(By targetElementlocator)
        {
            return InternalFinder(targetElementlocator);
        }

        protected IReadOnlyCollection<IWebElement> FindChildren(By parentLocator, By childLocator)
        {
            return WaitForElement(parentLocator).FindElements(childLocator);
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By targetElementlocator, By parentElementLocator = null)
        {
            if (parentElementLocator != null)
            {
                return new RetryPolicy(this, _simpleStrategy).ExecuteAction(() => new ReadOnlyCollection<IWebElement>(
                    FindChildren(parentElementLocator, targetElementlocator).Where(el => el.Displayed && el.Enabled).ToList()));
            }
            return new RetryPolicy(this, _simpleStrategy).ExecuteAction(() => new ReadOnlyCollection<IWebElement>(
                Driver.FindElements(targetElementlocator).Where(el => el.Displayed && el.Enabled).ToList()));
        }

        protected bool IsPresent (By targetElementlocator)
        {
            try
            {
                InternalFinder(targetElementlocator);

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

            protected IWebElement InternalFinder (By targetElementlocator)
        {
            try
                {
                    Log.TestLog.Info($"Wait element: {targetElementlocator}");
                    return new WebDriverWait(Driver, Configuration.DefaultWaitTimeout).Until(ExpectedConditions.ElementIsVisible(targetElementlocator));
                }
                catch (WebDriverTimeoutException)
                {
                    throw new Exception($"WebDriverTimeoutException: Element {targetElementlocator} was not found for {Configuration.DefaultWaitTimeout}");
                }
        }
    }
}
