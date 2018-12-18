using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Pages;

namespace ToyotaSpec
{
    [TestClass]
    public class TfsTest : BaseTest

    {
        [TestMethod]
        public void VinWalkTest()
        {
            var loginPage = new LoginPage();
            loginPage.LogIn(TestData.Login, TestData.Password);
            var homePage = new HomePage();
            homePage.TopMenuForm.NavigateTo(TopMenuItem.REPORTS);
            var reportsPage = new ReportsPage();
            reportsPage.NavigateTo(ReportsFormItem.VIN_WALK);
            var vinWalkPage = new VinWalkPage();
            var reportForm = new ReportForm(ReportName.VIN_WALK);
            reportForm.ClickUpdate();
            vinWalkPage.SortTableBy(VinWalkTableItem.YEAR);
            var vinWalkTabular = vinWalkPage.GetTabular();
            AssertTabularSort(vinWalkTabular);
        }

        private void AssertTabularSort(List<VINWalkTabular>  vinWalkTabular)
        {
            for (var index = 1; index < vinWalkTabular.Count; index++)
            {
                var firstCar = vinWalkTabular[index - 1];
                var secondCar = vinWalkTabular[index];
                Assert.IsTrue(firstCar.YEAR <= secondCar.YEAR,
                    $"Car {firstCar.YEAR} year is more than {secondCar.YEAR} car");
            }
        }
    }
}
