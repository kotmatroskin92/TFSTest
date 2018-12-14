using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;

namespace ToyotaSpec.Pages
{
    public class LoginPage : BaseForm
    {
        public LoginPage() : base(By.Id("username"), "Login page is open")
        {      
        }

    }
}
