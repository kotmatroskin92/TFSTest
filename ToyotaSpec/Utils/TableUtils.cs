using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestFramework.Objects;

namespace ToyotaSpec.Utils
{
    public class TableUtils: ElementFinder
    {
        private IWebElement _tableElement;
        private readonly By _headerRows = By.XPath(".//tr[position()=1]//th");
        private readonly By _dataRowsLocator = By.XPath(".//tr[not(position()=1)]");

        public TableUtils(By tableElementLocator)
        {
            _tableElement = WaitForElement(tableElementLocator);
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

        public IWebElement GetHeaderElementByIndex(int index)
        {
            return GetElementByIndex(_headerRows, index);
        }

        public ReadOnlyCollection<IWebElement> GetBodyElements()
        {
            return FindElements(_dataRowsLocator);
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
            var elements = FindElements(targetElementLocator);

            return elements[index];
        }
    }
}
