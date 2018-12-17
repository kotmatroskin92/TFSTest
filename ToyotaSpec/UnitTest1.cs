using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Pages;

namespace ToyotaSpec
{
    [TestClass]
    public class UnitTest1 : BaseTest

    {
        [TestMethod]
        public void TestMethod1()
        {
            var loginPage = new LoginPage();
            loginPage.LogIn("tfs.automation.admin", "Password1!");

            var homePage = new HomePage();
            homePage.TopMenuForm.NavigateTo(TopMenuItem.REPORTS);
            var reportsPage = new ReportsPage();
            reportsPage.NavigateTo(ReportsFormItem.VINWALK);
            var vinWalkPage = new VINWalkPage();
            var reportForm = new ReportForm(ReportName.VINWALK);
            reportForm.ClickUpdate();
            vinWalkPage.ParseTable();

        }
    }
}
