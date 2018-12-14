using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;

namespace ToyotaSpec.Pages
{
    public class LoginPage : BaseForm
    {
        private static readonly By txbUsername = By.Id("username");
        private static readonly By txbPassword = By.Id("password");
        private static readonly By btnLogin = By.XPath("//button[@type='submit']");

        public LoginPage() : base(txbUsername, "Login page is open")
        {      
        }

        public void TypeInUsername(string username)
        {
            WaitForElement(txbUsername).SendKeys(username);
        }

        public void TypeInPassword(string password)
        {
            WaitForElement(txbPassword).SendKeys(password);
        }

        public void ClickLogin()
        {
            WaitForElement(btnLogin).Click();
        }

        public void LogIn(string username, string password)
        {
            TypeInUsername(username);
            TypeInPassword(password);
            WaitForElement(btnLogin).Click();
        }
    }
}
