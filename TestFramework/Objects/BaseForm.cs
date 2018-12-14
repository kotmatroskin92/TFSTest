using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework.Objects
{
    class BaseForm : PageObject
    {
        protected WebDriverWait wait;

        protected BaseForm(By targetElementlocator)
        {
            Assert.IsTrue(IsPresent(targetElementlocator), "Element is not present");
        }
    }
}
