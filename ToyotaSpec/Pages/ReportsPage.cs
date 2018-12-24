using OpenQA.Selenium;
using TestFramework;
using TestFramework.Forms;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages
{
    public class ReportsPage: BaseForm
    {
        private static readonly string _tableLocator = "//table[@class='table']";

        public ReportsPage() : base(By.XPath(_tableLocator), "Reports page")
        {
        }

        public void NavigateTo(ReportsFormItem reportsItem)
        {
            WaitForElement(By.XPath($"{_tableLocator}//a[contains(@href, '{reportsItem}')]")).Click();
        }
    }
}
