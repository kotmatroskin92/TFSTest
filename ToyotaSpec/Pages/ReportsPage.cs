using System;
using OpenQA.Selenium;
using TestFramework.Objects;
using ToyotaSpec.Objects;
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
            WaitForElement(By.XPath(String.Format("{0}//a[contains(@href, '{1}')]", _tableLocator, reportsItem.ToString()))).Click();
        }
    }
}
