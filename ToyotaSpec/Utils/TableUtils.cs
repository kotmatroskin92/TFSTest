using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestFramework.Objects;

namespace ToyotaSpec.Utils
{
    public class TableUtils: ElementFinder
    {
        private readonly By _tableElementLocator;
        private readonly By _headerRows = By.XPath(".//tr[position()=1]//th");
        private readonly By _dataRowsLocator = By.XPath(".//tr[not(position()=1)]");

        public TableUtils(By tableElementLocator)
        {
            WaitForElement(tableElementLocator);
            _tableElementLocator = tableElementLocator;
        }

        public int GetIndexByText(By targetElementLocator, string text)
        {
            var elements = FindElements(targetElementLocator, _tableElementLocator);
            for (int index=0;  index < elements.Count; index++)
            {
                if (elements[index].Text == text)
                {
                    return index;
                }
            }

            return -1;
        }

        public IWebElement GetHeaderElementByIndex(int index)
        {
            return GetElementByIndex(_headerRows, index);
        }

        public ReadOnlyCollection<IWebElement> GetBodyElements()
        {
            return FindElements(_dataRowsLocator, _tableElementLocator);
        }

        public List<ReadOnlyCollection<IWebElement>> GetBodyCells()
        {
            var bodyElements = new List<ReadOnlyCollection<IWebElement>>();
            var elements = GetBodyElements();
            foreach(var element in elements)
            {
                bodyElements.Add(element.FindElements(By.TagName("td"))); 
            }

            return bodyElements;
        }

        protected IWebElement GetElementByIndex(By targetElementLocator, int index)
        {
            var elements = FindElements(targetElementLocator, _tableElementLocator);

            return elements[index];
        }
    }
}
