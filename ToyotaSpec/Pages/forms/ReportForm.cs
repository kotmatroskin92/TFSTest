using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages
{
    class ReportForm: BaseForm
    {
        private static readonly string lblReportNameTempl = "//*[@id='dropdownMenu2']//*[contains(text(), '{0}')]";
        private static readonly By btnSubmit = By.XPath("//button[contains(@class, 'submit-button') and not(@disabled)]");


        public ReportForm(ReportName reportName) : base(By.XPath(String.Format(lblReportNameTempl, reportName.ToString())), String.Format("{0} Report page", reportName.ToString()))
        {
        }

        public void ClickUpdate()
        {
            WaitForElement(btnSubmit).Click();
        }
    }
}
