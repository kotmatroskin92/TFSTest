﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TestFramework.Utils;
using ToyotaSpec.Enums;
using ToyotaSpec.Objects;
using ToyotaSpec.Pages;

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
            vinWalkPage.ClickExportCsv();
            var downloadedFile = DownloadUtil.WaitForDownload("vinwalk_*.csv", TimeSpan.FromSeconds(60)).First();
        }
    }
}
