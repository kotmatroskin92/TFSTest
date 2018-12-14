using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;

namespace ToyotaSpec.Pages.forms
{
    public class TopMenuForm : BaseForm
    {
        private static By topMenuLocator = By.CssSelector("#top [class='nav-list']");

        public TopMenuForm() : base(topMenuLocator, "Top menu")
        {
        }
    }
}
