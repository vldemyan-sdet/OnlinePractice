using OpenQA.Selenium;

namespace SeleniumPractice.Pages
{
    internal class SolarPage
    {
        public IWebDriver _driver;
        private By loader = By.Id("p_prldr");
        private By solarPanelsLink = By.CssSelector(".list-inline [href='/shop/solar-panels']");
        private By filterButton = By.CssSelector(".filter-button");
        private By productTitle = By.CssSelector(".card-content .list-product-title");

        public SolarPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.NavigateTo("https://solartechnology.com.ua/shop");

            WaitForLoader();
        }
        
        public void WaitForLoader()
        {
            _driver.WaitForElementVisible(loader);
            _driver.WaitForElementInvisible(loader);
        }

        public void OpenSolarPanels()
        {
            _driver.WaitAndClickElement(solarPanelsLink);

            WaitForLoader();
        }
        
        public void OpenFilters()
        {
            _driver.WaitAndClickElement(filterButton);
        }
                
        public void CheckBrand(string brand)
        {
            var brandCheckbox = By.XPath($"//*[@id='checkbox-brand']/following-sibling::span[text()='{brand}']");
            _driver.WaitAndClickElement(brandCheckbox);

            WaitForLoader();
        }
                        
        public string GetFirstProductTitleText()
        {
            return _driver.FindElement(productTitle).Text;
        }

    }
}