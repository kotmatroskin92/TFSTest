using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages
{
    class ReportPage: BaseForm
    {
        private static readonly string lblReportNameTempl = "//*[@id='dropdownMenu2']//*[contains(text(), '{0}')]";

        public ReportPage(ReportName reportName) : base(By.XPath(String.Format(lblReportNameTempl, reportName.ToString())), String.Format("{0} Report page", reportName.ToString()))
        {
        }

    }
}
