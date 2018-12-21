using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Utils;
using ToyotaSpec.Enums;
using ToyotaSpec.Models;
using ToyotaSpec.Objects;
using ToyotaSpec.Steps;

namespace ToyotaSpec.Tests
{
    [TestClass]
    public class TfsTest : BaseTest

    {
        [TestMethod]
        public void VinWalkTest()
        {
            Log.TestLog.Info("Step1: Login.");
            CommonSteps.Login(TestData.Login, TestData.Password);
            Log.TestLog.Info("Step2: Navigate to Reports - VinWalk");
            var vinWalkPage = CommonSteps.NavigateToVinWalkPage();
            Log.TestLog.Info("Step3: Sort VinWalk tabular by Year");
            vinWalkPage.SortTableBy(VinWalkTableItem.Year);
            var vinWalkTabular = vinWalkPage.GetVinYearTabular();
            Log.TestLog.Info("Step4: Assert tabular sorting");
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
