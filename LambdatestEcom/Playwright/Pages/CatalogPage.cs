using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class CatalogPage
    {
        private readonly IPage _page;

        public CatalogPage(IPage page)
        {
            _page = page;
        }

        public async Task FilterAvailability(string filterName)
        {

            await _page.Locator("#container .mz-filter-group.stock_status").GetByText(filterName).ClickAsync();
            await _page.WaitForURLAsync("**/*&mz_fss*");

            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task AddProductToCart(int productIndex)
        {
            await _page.WaitForTimeoutAsync(500);
            await _page.Locator(".product-thumb-top").Nth(productIndex).HoverAsync();
            await _page.WaitForTimeoutAsync(500);
            await _page.Locator(".product-thumb-top").Nth(productIndex).GetByRole(AriaRole.Button).Filter(new() { HasText = "Add to Cart" }).ClickAsync();
        }
        
        public async Task GoToCheckout()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Checkout" }).ClickAsync();
        }

        internal async Task UseExistingAddress()
        {
            await _page.Locator("#payment-address").GetByText("I want to use an existing").ClickAsync();
        }
    }
}
