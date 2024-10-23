using LambdatestEcom.Pages;
using System;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Steps 
{ 

    [Binding]
    public class CheckoutPageSteps : UITestFixture
    {
        public CheckoutPageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"use existing address option")]
        public async Task WhenUseExistingAddressOption()
        {
            await checkoutPage.UseExistingAddress();
        }

        [When(@"fill user info")]
        public async Task WhenFillUserInfo()
        {
            DateTime now = DateTime.Now;
            string randomString = now.ToString("yyyyMMddHHmmss");
            await checkoutPage.FillUserInfo(randomString);
        }

        [When(@"accepting Policy")]
        public async Task WhenAcceptingPolicy()
        {
            await checkoutPage.AcceptPolicy();
        }

        [When(@"accepting Terms and Conditions")]
        public async Task WhenAcceptingTermsAndConditions()
        {
            await checkoutPage.AcceptTermsAndConditions();
        }

        [When(@"confirming Order")]
        public async Task WhenConfirmingOrder()
        {
            await checkoutPage.ConfirmOrder();
        }

        [When(@"press Continue")]
        public async Task WhenPressContinue()
        {
            await checkoutPage.Continue();
        }

    }
}
