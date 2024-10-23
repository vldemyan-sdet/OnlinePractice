using LambdatestEcom.Pages;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace LambdatestEcom
{
    [Binding]
    public class UITestFixture
    {
        private readonly ScenarioContext _scenarioContext;
        public HomePage homePage { get; set; }
        public MyAccountPage myAccountPage { get; set; }
        public CatalogPage catalogPage { get; set; }
        public CheckoutPage checkoutPage { get; set; }

        public UITestFixture(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var page = _scenarioContext.Get<IPage>("page");
            homePage = new HomePage(page);
            myAccountPage = new MyAccountPage(page);
            catalogPage = new CatalogPage(page);
            checkoutPage = new CheckoutPage(page);
        }

    }
}
