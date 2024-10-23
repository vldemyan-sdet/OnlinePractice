using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class NewUserTests : UITestFixture
    {
        public NewUserTests() : base(false)
        {
        }

        [Test]
        public async Task CheckoutAsNewUser()
        {
            // Arrange
            DateTime now = DateTime.Now;
            string randomString = now.ToString("yyyyMMddHHmmss");

            var homePage = new HomePage(page);
            var myAccountPage = new MyAccountPage(page);
            var catalogPage = new CatalogPage(page);
            var checkoutPage = new CheckoutPage(page);

            // Act
            await homePage.Open();
            await homePage.OpenCategory("Laptops & Noteboks");

            await catalogPage.FilterAvailability("In stoc");
            await catalogPage.AddProductToCart(5);
            await catalogPage.GoToCheckout();

            await checkoutPage.FillUserInfo(randomString);
            await checkoutPage.AcceptTermsAndConditions();
            await checkoutPage.ConfirmOrder();
            await checkoutPage.Continue();

            await homePage.OpenMyAccount();
            await myAccountPage.OpenOrderHistory();
            var orderCount = await myAccountPage.GetOrderCount();

            // Assert
            Assert.That(orderCount, Is.EqualTo(1));
        }        
        

    }
}
