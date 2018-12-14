//using AutoTests.Framework.Enums;
//using AutoTests.Framework.Selenium;
//using AutoTests.Framework.Utils;
//using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestFramework.Objects
{
    public abstract class PageObject : ApplicationBase
    {

        protected PageObject()
        {
        }

        protected IWebDriver Driver
        {
            get { return LazyDriver; }
        }

        protected IWebElement WaitForElement(By targetElementlocator)
        {
            return InternalFinder(targetElementlocator);
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
                    return new WebDriverWait(Driver, Configuration.DefaultWaitTimeout).Until(ExpectedConditions.ElementIsVisible(targetElementlocator));
                }
                catch (WebDriverTimeoutException)
                {
                    throw new Exception($"WebDriverTimeoutException: Element {targetElementlocator} was not found for {Configuration.DefaultWaitTimeout}");
                }
        }
    }
}
