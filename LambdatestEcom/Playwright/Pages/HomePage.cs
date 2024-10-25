using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task Open()
        {
            await _page.GotoAsync("https://ecommerce-playground.lambdatest.io");
        }

        public async Task OpenCategory(string name)
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Shop by Category" }).ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = name }).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task OpenMyAccount()
        {

            await _page.GetByRole(AriaRole.Button, new() { Name = "My account" }).ClickAsync();

            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    }
}
