﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        [ClassInitialize]
        public static void InitBeforeClass(TestContext context)
        {
            DownloadUtil.ClearDir();
        }

        [TestMethod]
        public void ExportCsv()
        {
            var softAssertions = new SoftAssertions();
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
            for (var index = 0; index < uiTabular.Count; index++)
            {
                softAssertions.IsTrue(uiTabular[index].Equals(csvTabular[index]), $"Car from UI row={index+1}, VIN={uiTabular[index].VIN} is not equal car from CSV row={index+1}, VIN={csvTabular[index].VIN}");
            }
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void ExportExcel()
        {
            var softAssertions = new SoftAssertions();
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
            for (var index = 0; index < uiTabular.Count; index++)
            {
                softAssertions.IsTrue(uiTabular[index].Equals(excelTabular[index]), $"Car from UI row={index + 1}, VIN={uiTabular[index].VIN} is not equal car from Excel row={index + 1}, VIN={excelTabular[index].VIN}");
            }
            softAssertions.AssertAll();
        }
    }
}
