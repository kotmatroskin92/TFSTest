using OpenQA.Selenium;
using TestFramework.Objects;
using ToyotaSpec.Pages.forms;

namespace ToyotaSpec.Pages
{
    public class HomePage : BaseForm
    {
        private static readonly By _lblHomePage = By.XPath("//section[@id='module-content']/div[contains(@class, 'dashboard')]");
        public TopMenuForm TopMenuForm => new TopMenuForm();

        public HomePage() : base(_lblHomePage, "Home page")
        {
        }

    }
}
