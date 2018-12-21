using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TestFramework.Utils;
using ToyotaSpec.Constants;
using ToyotaSpec.Enums;
using ToyotaSpec.Models;
using ToyotaSpec.Objects;
using ToyotaSpec.Pages;
using ToyotaSpec.Utils;

namespace ToyotaSpec
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
            var loginPage = new LoginPage();
            loginPage.LogIn(TestData.Login, TestData.Password);
            var homePage = new HomePage();
            homePage.TopMenuForm.NavigateTo(TopMenuItem.Reports);
            var reportsPage = new ReportsPage();
            reportsPage.NavigateTo(ReportsFormItem.VinWalk);
            var vinWalkPage = new VinWalkPage();
            var reportForm = new ReportForm(ReportName.VinWalk);
            reportForm.ClickUpdate();
            vinWalkPage.ClickExportCsv();
            var downloadedFile = DownloadUtil.WaitForDownload(FileNamePattern.VinWalkCsv).First();
            var csvUtils = new CsvUtils(downloadedFile);
            var csvTabular = csvUtils.GetListOf<VinWalkTabular>();
            var uiTabular = vinWalkPage.GetFullTabular();
            AssertTabularEquals(uiTabular, csvTabular, "CSV");
        }

        [TestMethod]
        public void ExportExcel()
        {
            var loginPage = new LoginPage();
            loginPage.LogIn(TestData.Login, TestData.Password);
            var homePage = new HomePage();
            homePage.TopMenuForm.NavigateTo(TopMenuItem.Reports);
            var reportsPage = new ReportsPage();
            reportsPage.NavigateTo(ReportsFormItem.VinWalk);
            var vinWalkPage = new VinWalkPage();
            var reportForm = new ReportForm(ReportName.VinWalk);
            reportForm.ClickUpdate();
            vinWalkPage.ClickExportExcel();
            var downloadedFile = DownloadUtil.WaitForDownload(FileNamePattern.VinWalkXlsx).First();
            var excel = new ExcelUtils(downloadedFile);
            var excelTabular = excel.ExcelWorksheet().GetListOf<VinWalkTabular>(new Dictionary<string, string>{{"Misc.", "Misc"}});
            var uiTabular = vinWalkPage.GetFullTabular();
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
