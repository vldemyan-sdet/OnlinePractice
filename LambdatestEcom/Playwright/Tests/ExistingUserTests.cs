using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExistingUserTests : UITestFixture
    {
        public ExistingUserTests() : base(true)
        {
        }

        [SetUp]
        public async Task Login()
        {
            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");
            if (page.Url.EndsWith("?route=account/login"))
            {
                await page.GetByPlaceholder("E-Mail Address").FillAsync("alex.conner20241021231030@jmail.com");
                await page.GetByPlaceholder("Password").FillAsync("qweasd");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                await context.StorageStateAsync(new()
                {
                    Path = stateFile
                });
            }
        }

        [Test]
        public async Task CheckoutAsExistingUser()
        {
            // Arrange
            var homePage = new HomePage(page);
            var myAccountPage = new MyAccountPage(page);
            var catalogPage = new CatalogPage(page);
            var checkoutPage = new CheckoutPage(page);

            // Act
            await homePage.Open();
            await homePage.OpenMyAccount();
            await myAccountPage.OpenOrderHistory();
            var orderCountBefore = await myAccountPage.GetOrderCount();
            await homePage.OpenCategory("Laptops & Notebooks");

            await catalogPage.FilterAvailability("In stock");
            await catalogPage.AddProductToCart(5);
            await catalogPage.GoToCheckout();
            await catalogPage.UseExistingAddress();

            await checkoutPage.AcceptTermsAndConditions();
            await checkoutPage.ConfirmOrder();
            await checkoutPage.Continue();

            await homePage.OpenMyAccount();
            await myAccountPage.OpenOrderHistory();
            var orderCountAfter = await myAccountPage.GetOrderCount();

            // Assert
            Assert.That(orderCountAfter, Is.EqualTo(orderCountBefore - 1));
        }

    }
}
