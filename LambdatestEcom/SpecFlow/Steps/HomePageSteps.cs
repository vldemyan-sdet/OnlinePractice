using LambdatestEcom.Pages;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps 
{ 

    [Binding]
    public class HomePageSteps : UITestFixture
    {

        public HomePageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"open home page")]
        public async Task GivenOpenHomePageAsync()
        {
            await homePage.Open();
        }

        [Given(@"open My account")]
        public async Task GivenOpenMyAccount()
        {
            await homePage.OpenMyAccount();
        }


        [When(@"open category '([^']*)'")]
        public async Task WhenOpenCategory(string categoryName)
        {
            await homePage.OpenCategory(categoryName);
        }

    }
}
