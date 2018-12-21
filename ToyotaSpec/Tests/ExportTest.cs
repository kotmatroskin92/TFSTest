using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Utils;
using ToyotaSpec.Constants;
using ToyotaSpec.Models;
using ToyotaSpec.Objects;
using ToyotaSpec.Steps;
using ToyotaSpec.Utils;

namespace ToyotaSpec.Tests
{
    [TestClass]
    public class ExportTest : BaseTest
    {
        private readonly SoftAssertions _softAssertions = new SoftAssertions();

        [ClassInitialize]
        public static void InitBeforeClass(TestContext context)
        {
            DownloadUtil.ClearDir();
        }

        [TestMethod]
        public void ExportCsv()
        {
            Log.TestLog.Info("Step1: Login.");
            CommonSteps.Login(TestData.Login, TestData.Password);
            Log.TestLog.Info("Step2: Navigate to Reports - VinWalk");
            var vinWalkPage = CommonSteps.NavigateToVinWalkPage();
            Log.TestLog.Info("Step3: Export csv tabular");
            vinWalkPage.ClickExportCsv();
            var downloadedFile = DownloadUtil.WaitForDownload(FileNamePattern.VinWalkCsv).First();
            var csvUtils = new CsvUtils(downloadedFile);
            Log.TestLog.Info("Step4: Parse csv tabular");
            var csvTabular = csvUtils.GetListOf<VinWalkTabular>();
            Log.TestLog.Info("Step5: Parse ui tabular");
            var uiTabular = vinWalkPage.GetFullTabular();
            Log.TestLog.Info("Step6: Assert tabular");
            AssertTabularEquals(uiTabular, csvTabular, "CSV");
        }

        [TestMethod]
        public void ExportExcel()
        {
            Log.TestLog.Info("Step1: Login.");
            CommonSteps.Login(TestData.Login, TestData.Password);
            Log.TestLog.Info("Step2: Navigate to Reports - VinWalk");
            var vinWalkPage = CommonSteps.NavigateToVinWalkPage();
            Log.TestLog.Info("Step3: Export csv tabular");
            vinWalkPage.ClickExportExcel();
            var downloadedFile = DownloadUtil.WaitForDownload(FileNamePattern.VinWalkXlsx).First();
            Log.TestLog.Info("Step4: Parse excel tabular");
            var excel = new ExcelUtils(downloadedFile);
            var excelTabular = excel.ExcelWorksheet().GetListOf<VinWalkTabular>(new Dictionary<string, string>{{"Misc.", "Misc"}});
            Log.TestLog.Info("Step5: Parse ui tabular");
            var uiTabular = vinWalkPage.GetFullTabular();
            Log.TestLog.Info("Step6: Assert tabular");
            AssertTabularEquals(uiTabular, excelTabular, "Excel");
        }

        private void AssertTabularEquals(List<VinWalkTabular> uiTabular, List<VinWalkTabular> fileTabular, string fileType)
        {
            for (var index = 0; index < uiTabular.Count; index++)
            {
                _softAssertions.IsTrue(uiTabular[index].Equals(fileTabular[index]), $"Car from UI row={index + 1}, VIN={uiTabular[index].VIN} is not equal car from {fileType} row={index + 1}, VIN={fileTabular[index].VIN}");
            }
            _softAssertions.AssertAll();
        }

    }
}
