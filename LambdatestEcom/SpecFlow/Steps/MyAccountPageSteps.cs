using LambdatestEcom.Pages;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps 
{ 

    [Binding]
    public class MyAccountPageSteps : UITestFixture
    {
        readonly ScenarioContext _scenarioContext;

        public MyAccountPageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"open Order History")]
        public async Task GivenOpenOrderHistory()
        {
            await myAccountPage.OpenOrderHistory();
        }

        [Given(@"note number of orders on Order History")]
        public async Task GivenNoteNumberOfOrdersOnOrderHistory()
        {
            var orderCountBefore = await myAccountPage.GetOrderCount();
            _scenarioContext["orderCountBefore"] = orderCountBefore;
        }

        [Then(@"new order appeared on Order History")]
        public async Task ThenNewOrderAppearedOnOrderHistory()
        {
            var orderCountBefore = _scenarioContext.Get<int>("orderCountBefore");
            var orderCountAfter = await myAccountPage.GetOrderCount();
            Assert.That(orderCountAfter, Is.EqualTo(orderCountBefore + 1));
        }

        [Then(@"single order is present on Order History")]
        public async Task ThenSingleOrderIsPresentOnOrderHistory()
        {
            var orderCount = await myAccountPage.GetOrderCount();
            Assert.That(orderCount, Is.EqualTo(1));
        }


    }
}
