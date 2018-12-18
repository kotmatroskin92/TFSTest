using OpenQA.Selenium;
using TestFramework.Objects;
using ToyotaSpec.Objects;
using ToyotaSpec.Enums;

namespace ToyotaSpec.Pages.forms
{
    public class TopMenuForm : BaseForm
    {
        private static readonly By _topMenuLocator = By.CssSelector("#top [class='nav-list']");

        public TopMenuForm() : base(_topMenuLocator, "Top menu")
        {
        }

        public void NavigateTo(TopMenuItem topMenuItem)
        {
            WaitForElement(By.CssSelector(topMenuItem.ToString())).Click();
        }
    }
}
