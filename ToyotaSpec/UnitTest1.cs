using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Objects;
using ToyotaSpec.Pages;

namespace ToyotaSpec
{
    [TestClass]
    public class UnitTest1 : BaseTest

    {
        [TestMethod]
        public void TestMethod1()
        {
            var loginPage = new LoginPage();
            loginPage.LogIn("tfs.automation.admin", "Password1!");
            new LoginPage();
        }
    }
}
