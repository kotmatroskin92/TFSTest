using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestFramework.Objects;

namespace ToyotaSpec.Utils
{
    public class TableUtils: ElementFinder
    {
        private IWebElement tableElement;
        private readonly By headerRows = By.XPath(".//tr[position()=1]//th");
        private readonly By dataRowsLocator = By.XPath(".//tr[not(position()=1)]");

        public TableUtils(By tableElementLocator)
        {
            this.tableElement = WaitForElement(tableElementLocator);
        }

        public int GetIndexByText(By targetElementLocator, string text)
        {
            var elements = FindElements(targetElementLocator);
            for (int index=0;  index < elements.Count; index++)
            {
                if (elements[index].Text == text)
                {
                    return index;
                }
            }
            return -1;
        }

        protected IWebElement GetElementByIndex(By targetElementLocator, int index)
        {
            var elements = FindElements(targetElementLocator);
            return elements[index];
        }

        public IWebElement GetHeaderElementByIndex(int index)
        {
            return GetElementByIndex(this.headerRows, index);
        }

        public ReadOnlyCollection<IWebElement> GetBodyElements()
        {
            var elements = FindElements(this.dataRowsLocator);
            return elements;
        }

        public List<ReadOnlyCollection<IWebElement>> GetBodyCells()
        {
            List<ReadOnlyCollection<IWebElement>> bodyElements = new List<ReadOnlyCollection<IWebElement>>();
            var elements = GetBodyElements();
            foreach(var element in elements)
            {
                bodyElements.Add(element.FindElements(By.TagName("td"))); 
            }
            return bodyElements;
        }
    }
}
