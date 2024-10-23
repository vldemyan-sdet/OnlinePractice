using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    public class CatalogPage
    {
        private readonly IPage _page;

        public CatalogPage(IPage page)
        {
            _page = page;
        }

        public async Task FilterAvailability(string filterName)
        {

            await _page.Locator("#container .mz-filter-group.stock_status").GetByText("In stock").ClickAsync();
            await _page.WaitForURLAsync("**/*&mz_fss*");

            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task AddProductToCart(int productIndex)
        {
            await _page.Locator(".product-thumb-top").Nth(productIndex).HoverAsync();
            await _page.Locator(".product-thumb-top").Nth(productIndex).GetByRole(AriaRole.Button).Filter(new() { HasText = "Add to Cart" }).ClickAsync();
        }
        
        public async Task GoToCheckout()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Checkout" }).ClickAsync();
        }

    }
}
