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
        //private static readonly By headerRows = By.XPath(".//tr[position()=1]//th");
        //private static readonly By dataRowsLocator = By.XPath(".//tr[not(position()=1)]");

        public VINWalkPage(): base(lblIsSold, "VIN Walk page")
        {
        }

        public void SortTableBy(VinWalkTableItem vinWalkTable)
        {
            var element = new TableUtils(tableTabular).GetHeaderElementByIndex(vinWalkTable.Value);
            if (element.Text == vinWalkTable.ToString())
            {
                element.Click();
            }
        }

        public List<VINWalkTabular> GetTabulars()
        {
            List<VINWalkTabular> listTabular = new List<VINWalkTabular>(); 
            var table = new TableUtils(tableTabular);
            var bodyCells = table.GetBodyCells();
            foreach (var cells in bodyCells)
            {
                listTabular.Add(new VINWalkTabular(cells[VinWalkTableItem.VIN.Value].Text, Int32.Parse(cells[VinWalkTableItem.YEAR.Value].Text)));
            }
            return listTabular;
        }

    }
}
