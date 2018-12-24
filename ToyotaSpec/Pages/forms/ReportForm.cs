using System;
using OpenQA.Selenium;
using TestFramework;
using TestFramework.Forms;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages
{
    class ReportForm: BaseForm
    {
        private static readonly string _lblReportNameTemplate = "//*[@id='dropdownMenu2']//*[contains(text(), '{0}')]";
        private static readonly By _btnSubmit = By.XPath("//button[contains(@class, 'submit-button') and not(@disabled)]");
        
        public ReportForm(ReportName reportName) : 
            base(By.XPath(String.Format(_lblReportNameTemplate, reportName)),
                $"{reportName} Report page")
        {
        }

        public void ClickUpdate()
        {
            WaitForElement(_btnSubmit).Click();
        }
    }
}
