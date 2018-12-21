using OpenQA.Selenium;
using System.Collections.Generic;
using TestFramework.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Models;
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

        public List<VinWalkTabular> GetFullTabular()
        {
            var tabularList = new List<VinWalkTabular>(); 
            var table = new TableUtils(_tableTabular);
            var bodyCells = table.GetBodyCells();
            foreach (var cells in bodyCells)
            {
                tabularList.Add(new VinWalkTabular(
                    cells[VinWalkTableItem.Vin.Value].Text,
                    int.Parse(cells[VinWalkTableItem.Year.Value].Text),
                    cells[VinWalkTableItem.Make.Value].Text,
                    cells[VinWalkTableItem.Model.Value].Text,
                    cells[VinWalkTableItem.Trim.Value].Text,
                    cells[VinWalkTableItem.Mmr.Value].Text,
                    cells[VinWalkTableItem.Mileage.Value].Text,
                    cells[VinWalkTableItem.Location.Value].Text,
                    cells[VinWalkTableItem.Condition.Value].Text,
                    cells[VinWalkTableItem.Color.Value].Text,
                    cells[VinWalkTableItem.Content.Value].Text,
                    cells[VinWalkTableItem.CarFax.Value].Text,
                    cells[VinWalkTableItem.Structural.Value].Text,
                    cells[VinWalkTableItem.TimesRun.Value].Text,
                    cells[VinWalkTableItem.SalesChannel.Value].Text,
                    cells[VinWalkTableItem.Misc.Value].Text,
                    cells[VinWalkTableItem.Manual.Value].Text,
                    cells[VinWalkTableItem.Floor.Value].Text,
                    cells[VinWalkTableItem.Status.Value].Text,
                    cells[VinWalkTableItem.SalePrice.Value].Text,
                    cells[VinWalkTableItem.SoldDate.Value].Text,
                    cells[VinWalkTableItem.PricingRule.Value].Text,
                    cells[VinWalkTableItem.DatePriced.Value].Text));
            }

            return tabularList;
        }

        public List<VinWalkTabular> GetVinYearTabular()
        {
            var tabularList = new List<VinWalkTabular>();
            var table = new TableUtils(_tableTabular);
            var bodyCells = table.GetBodyCells();
            foreach (var cells in bodyCells)
            {
                tabularList.Add(new VinWalkTabular
                {
                    VIN = cells[VinWalkTableItem.Vin.Value].Text,
                    Year = int.Parse(cells[VinWalkTableItem.Year.Value].Text)
                });
            }

            return tabularList;
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
