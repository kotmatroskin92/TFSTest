using OpenQA.Selenium;
using TestFramework.Elements;

namespace TestFramework.Forms
{
    public class BaseForm : ElementFinder
    {
        protected BaseForm(By targetElementLocator, string formName)
        {
            WaitForElement(targetElementLocator);
            Log.TestLog.Info(formName + " was opened");
        }
    }
}
