using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyotaSpec.Objects
{
    public class BaseForm : ElementFinder
    {
        protected WebDriverWait wait;

        protected BaseForm(By targetElementlocator, String formName)
        {
            Assert.IsTrue(IsPresent(targetElementlocator), "Element is not present");
            Log.Console.Info(formName + " was opened");
        }
    }
}
