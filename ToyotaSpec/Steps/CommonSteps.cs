using TestFramework.Objects;
using ToyotaSpec.Enums;
using ToyotaSpec.Pages;

namespace ToyotaSpec.Steps
{
    public class CommonSteps: ApplicationBase
    {
        private static HomePage _homePage;

        public static void Login(string login, string password)
        {
            var loginPage = new LoginPage();
            loginPage.LogIn(login, password);
            _homePage = new HomePage();
        }

        public static VinWalkPage NavigateToVinWalkPage()
        {
            _homePage.TopMenuForm.NavigateTo(TopMenuItem.Reports);
            var reportsPage = new ReportsPage();
            reportsPage.NavigateTo(ReportsFormItem.VinWalk);
            var vinWalkPage = new VinWalkPage();
            var reportForm = new ReportForm(ReportName.VinWalk);
            reportForm.ClickUpdate();
            return vinWalkPage;
        }
    }
}
