using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyotaSpec.Objects
{
    public class BaseForm : ElementFinder
    {
        protected BaseForm(By targetElementlocator, string formName)
        {
            Assert.IsTrue(IsPresent(targetElementlocator), "Element is not present");
            Log.Console.Info(formName + " was opened");
        }
    }
}
