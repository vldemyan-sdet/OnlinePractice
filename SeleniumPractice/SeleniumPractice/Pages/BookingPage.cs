using OpenQA.Selenium;

namespace SeleniumPractice.Pages
{
    internal class BookingPage
    {
        public IWebDriver _driver;
        private By cityInput = By.CssSelector("[name='ss']");
        private By popupCloseIcon = By.CssSelector("[role='dialog'] svg");
        private By datesSelect = By.CssSelector("[data-testid='searchbox-dates-container']");
        private By searchButton = By.CssSelector("button[type='submit']");
        private By roomResultCard = By.CssSelector("[data-testid='property-card']");
        private string distanceFilterGroupFormat = "//*[@id='bodyconstraint']//*[@data-filters-group = 'distance']//*[@data-filters-item='distance:distance={0}']";

        


        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.NavigateTo("https://www.booking.com");
            Thread.Sleep(2000);
            //_driver.WaitForElementVisible(popupCloseIcon);
        
        }
        
        public void FillCity(string city)
        {
            _driver.FillInput(cityInput, city);
        }
                   
        public void FillDates(string from, string to)
        {
            var fromDateSelector = By.CssSelector($"[data-date='{from}']");
            var toDateSelector = By.CssSelector($"[data-date='{to}']");
            _driver.ClickElement(datesSelect);

            _driver.ClickElement(fromDateSelector);
            _driver.ClickElement(toDateSelector);
        }
                           
        public void ClickSearch()
        {
            _driver.ClickElement(searchButton);
            Thread.Sleep(2000);
        }

        public void FilterByDistanceToCenter(int km)
        {
            var locator = string.Format(distanceFilterGroupFormat, km * 1000);
            var element = _driver.FindElement(By.XPath(locator));
            _driver.ScrollTo(element);
            element.Click();
        }


        internal void CloseRegisterPopup()
        {
            if(_driver.FindElements(popupCloseIcon).Count > 0)
            {
                _driver.ClickElement(popupCloseIcon);
            }
        }

        internal IEnumerable<IWebElement> GetRoomsSearchResults()
        {
            return _driver.FindElements(roomResultCard);
        }
    }
}