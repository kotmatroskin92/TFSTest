using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;
using ToyotaSpec.Pages.forms;

namespace ToyotaSpec.Pages
{
    public class HomePage : BaseForm
    {
        private static By lblHomePage = By.XPath("//section[@id='module-content' and text()='Home']");
        public TopMenuForm TopMenuForm => new TopMenuForm();

        public HomePage() : base(lblHomePage, "Home page")
        {
        }

    }
}
