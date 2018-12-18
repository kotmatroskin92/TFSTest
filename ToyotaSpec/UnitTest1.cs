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
            vinWalkPage.SortTableBy(VinWalkTableItem.YEAR);
            var vinWalkTabulars = vinWalkPage.GetTabulars();
            for ( var index=1; index < vinWalkTabulars.Count; index++)
            {
                var firstCar = vinWalkTabulars[index - 1];
                var secondCar = vinWalkTabulars[index];
                Assert.IsTrue(firstCar.YEAR <= secondCar.YEAR,
                    string.Format("Car {0} year is more than {1} car", firstCar.YEAR, secondCar.YEAR));
            }
        }
    }
}
