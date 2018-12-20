using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TestFramework.Objects;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Utils;

namespace ToyotaSpec.Pages
{
    public class VinWalkPage: BaseForm
    {
        private static readonly By _lblIsSold = By.Id("facet-checkboxGroup-IsSold");
        private static readonly By _tableTabular = By.XPath("//div[@id='visualization-Tabular']");
        private static readonly By _btnExportCsv = By.Id("export-Csv");
        private static readonly By _btnExportExcel = By.Id("export-Excel");

        public VinWalkPage(): base(_lblIsSold, "VIN Walk page")
        {
        }

        public void SortTableBy(VinWalkTableItem vinWalkTable)
        {
            var element = new TableUtils(_tableTabular).GetHeaderElementByIndex(vinWalkTable.Value);
            if (element.Text == vinWalkTable.ToString())
            {
                element.Click();
            }
        }

        public List<VinWalkTabular> GetTabular()
        {
            List<VinWalkTabular> listTabular = new List<VinWalkTabular>(); 
            var table = new TableUtils(_tableTabular);
            var bodyCells = table.GetBodyCells();
            foreach (var cells in bodyCells)
            {
                listTabular.Add(new VinWalkTabular(
                    cells[VinWalkTableItem.Vin.Value].Text,
                    Int32.Parse(cells[VinWalkTableItem.Year.Value].Text)));
            }

            return listTabular;
        }

        public void ClickExportCsv()
        {
            WaitForElement(_btnExportCsv).Click();
        } 

        public void ClickExportExcel()
        {
            WaitForElement(_btnExportExcel).Click();
        } 

    }
}
