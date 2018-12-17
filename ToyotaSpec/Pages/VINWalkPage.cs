using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;
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

        public void ParseTable()
        {
            var table = new TableUtils(tableTabular);
            var el = table.GetHeaderElementByIndex(1).Text;
            var ell = table.GetBodyCells();
            var text = ell[0][1].Text;
        }

    }
}
