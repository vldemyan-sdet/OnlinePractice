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
        


        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.NavigateTo("https://www.booking.com");
            _driver.WaitForElementVisible(popupCloseIcon);
        
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
        }


        internal void CloseRegisterPopup()
        {
            _driver.ClickElement(popupCloseIcon);
        }

        internal IEnumerable<IWebElement> GetRoomsSearchResults()
        {
            return _driver.FindElements(roomResultCard);
        }
    }
}