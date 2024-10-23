using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    public class MyAccountPage
    {
        private readonly IPage _page;

        public MyAccountPage(IPage page)
        {
            _page = page;
        }

        public async Task OpenOrderHistory()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "View your order history" }).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        internal async Task<int> GetOrderCount()
        {
            var ordersAndPagesText = await _page.Locator("#content").GetByText("Showing ").TextContentAsync();
            // example test: "Showing 1 to 10 of 11 (2 Pages)"
            var numberOfOrders = int.Parse(ordersAndPagesText.Split(" of ")[1].Split(' ')[0]);
            return numberOfOrders;
        }
    }
}
