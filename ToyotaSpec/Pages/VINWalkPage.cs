using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Objects;
using ToyotaSpec.Utils;

namespace ToyotaSpec.Pages
{
    public class VINWalkPage: BaseForm
    {
        private static readonly By lblIsSold = By.Id("facet-checkboxGroup-IsSold");
        private static readonly By tableTabular = By.XPath("//div[@id='visualization-Tabular']");
        private static readonly By headerRows = By.XPath(".//tr[position()=1]//th");
        private static readonly By dataRowsLocator = By.XPath(".//tr[not(position()=1)]");

        public VINWalkPage(): base(lblIsSold, "VIN Walk page")
        {
        }

        public void SortTableBy(VinWalkTable vinWalkTable)
        {
            var element = new TableUtils(tableTabular).GetHeaderElementByIndex(vinWalkTable.Value);
            if (element.Text == vinWalkTable.ToString())
            {
                element.Click();
            }
        }

        public void ParseTable()
        {
            List<VINWalkTabular> ListTabular = new List<VINWalkTabular>(); 
            var table = new TableUtils(tableTabular);
            var bodyCells = table.GetBodyCells();
            var text = bodyCells[2][1].Text;
        }

    }
}
