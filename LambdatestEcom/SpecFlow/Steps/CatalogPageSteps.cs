using LambdatestEcom.Pages;
using System;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps 
{ 

    [Binding]
    public class CatalogPageSteps : UITestFixture
    {
        public CatalogPageSteps(ScenarioContext scenarioContext) : base(scenarioContext) 
        {
        }


        [When(@"filter in stock items")]
        public async Task WhenFilterInStockItems()
        {
            await catalogPage.FilterAvailability("In stock");
        }

        [When(@"add product number (.*) to Cart")]
        public async Task WhenAddProductNumberToCart(int productNumber)
        {
            await catalogPage.AddProductToCart(productNumber - 1);
        }

        [When(@"go to Checkout")]
        public async Task WhenGoToCheckout()
        {
            await catalogPage.GoToCheckout();
        }

    }
}
