using OpenQA.Selenium;
using ToyotaSpec.Objects;
using ToyotaSpec.Pages.forms;

namespace ToyotaSpec.Pages
{
    public class HomePage : BaseForm
    {
        private static readonly By _lblHomePage = By.XPath("//section[@id='module-content' and text()='Home']");
        public TopMenuForm TopMenuForm => new TopMenuForm();

        public HomePage() : base(_lblHomePage, "Home page")
        {
        }

    }
}
