using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Utils;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Models;
using ToyotaSpec.Pages;

namespace ToyotaSpec
{
    [TestClass]
    public class TfsTest : BaseTest

    {
        [TestMethod]
        public void VinWalkTest()
        {
            Log.TestLog.Info("Step1: Login.");
            var loginPage = new LoginPage();
            loginPage.LogIn(TestData.Login, TestData.Password);
            var homePage = new HomePage();
            Log.TestLog.Info($"Step2: Navigate to Reports - VinWalk");
            homePage.TopMenuForm.NavigateTo(TopMenuItem.Reports);
            var reportsPage = new ReportsPage();
            reportsPage.NavigateTo(ReportsFormItem.VinWalk);
            var vinWalkPage = new VinWalkPage();
            var reportForm = new ReportForm(ReportName.VinWalk);
            reportForm.ClickUpdate();
            Log.TestLog.Info($"Step4: Sort VinWalk tabular by Year");
            vinWalkPage.SortTableBy(VinWalkTableItem.Year);
            var vinWalkTabular = vinWalkPage.GetVinYearTabular();
            Log.TestLog.Info($"Step5: Assert tabular sorting");
            AssertTabularSort(vinWalkTabular);
        }

        private void AssertTabularSort(List<VinWalkTabular>  vinWalkTabular)
        {
            var softAssert = new SoftAssertions();
            for (var index = 1; index < vinWalkTabular.Count; index++)
            {
                var firstCar = vinWalkTabular[index - 1];
                var secondCar = vinWalkTabular[index];
                softAssert.IsTrue(firstCar.Year <= secondCar.Year,
                    $"Car {firstCar.Year} year is more than {secondCar.Year} car");
            }
            softAssert.AssertAll();
        }
    }
}
