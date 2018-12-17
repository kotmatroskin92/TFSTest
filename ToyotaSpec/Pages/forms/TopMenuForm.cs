using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages.forms
{
    public class TopMenuForm : BaseForm
    {
        private static By topMenuLocator = By.CssSelector("#top [class='nav-list']");

        public TopMenuForm() : base(topMenuLocator, "Top menu")
        {
        }

        public void NavigateTo(TopMenuItem topMenuItem)
        {
            WaitForElement(By.CssSelector(topMenuItem.ToString())).Click();
        }
    }
}
