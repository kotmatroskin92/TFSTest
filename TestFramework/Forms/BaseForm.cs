using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestFramework.Elements;

namespace TestFramework.Forms
{
    public class BaseForm : ElementFinder
    {
        protected BaseForm(By targetElementlocator, string formName)
        {
            Assert.IsTrue(IsPresent(targetElementlocator), "Element is not present");
            Log.TestLog.Info(formName + " was opened");
        }
    }
}
