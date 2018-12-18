using System;
using OpenQA.Selenium;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages
{
    class ReportForm: BaseForm
    {
        private static readonly string _lblReportNameTempl = "//*[@id='dropdownMenu2']//*[contains(text(), '{0}')]";
        private static readonly By _btnSubmit = By.XPath("//button[contains(@class, 'submit-button') and not(@disabled)]");


        public ReportForm(ReportName reportName) : 
            base(By.XPath(String.Format(_lblReportNameTempl, reportName.ToString())),
                 String.Format("{0} Report page", reportName.ToString()))
        {
        }

        public void ClickUpdate()
        {
            WaitForElement(_btnSubmit).Click();
        }
    }
}
