using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages
{
    public class ReportsPage: BaseForm
    {
        private static string tableLocator = "//table[@class='table']";

        public ReportsPage() : base(By.XPath(tableLocator), "Reports page")
        {
        }

        public void NavigateTo(ReportsFormItem reportsItem)
        {
            WaitForElement(By.XPath(String.Format("{0}//a[contains(@href, '{1}')]", tableLocator, reportsItem.ToString()))).Click();
        }
    }
}
