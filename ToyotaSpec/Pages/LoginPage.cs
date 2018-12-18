using OpenQA.Selenium;
using ToyotaSpec.Objects;

namespace ToyotaSpec.Pages
{
    public class LoginPage : BaseForm
    {
        private static readonly By _txbUsername = By.Id("username");
        private static readonly By _txbPassword = By.Id("password");
        private static readonly By _btnLogin = By.XPath("//button[@type='submit']");

        public LoginPage() : base(_txbUsername, "Login page")
        {      
        }

        public void TypeInUsername(string username)
        {
            WaitForElement(_txbUsername).SendKeys(username);
        }

        public void TypeInPassword(string password)
        {
            WaitForElement(_txbPassword).SendKeys(password);
        }

        public void ClickLogin()
        {
            WaitForElement(_btnLogin).Click();
        }

        public void LogIn(string username, string password)
        {
            TypeInUsername(username);
            TypeInPassword(password);
            WaitForElement(_btnLogin).Click();
        }
    }
}
