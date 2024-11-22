using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPractice.Tests
{
    public class BaseClass
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired browser resolution
            //options.AddArguments("headless");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _js = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}