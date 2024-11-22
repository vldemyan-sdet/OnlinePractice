using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace SeleniumPractice
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void NavigateTo(this IWebDriver driver, string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        public static void WaitForElementVisible(this IWebDriver driver, By by, int sec = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(d => d.FindElement(by).Displayed);
        }

        public static void WaitForElementInvisible(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => !d.FindElement(by).Displayed);
        }

        public static void WaitForElementEnabled(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);
        }

        public static void WaitAndClickElement(this IWebDriver driver, By selector)
        {
            var timeStart = DateTime.Now;
            WaitForElementVisible(driver, selector);
            var timeEnd = DateTime.Now;
            Console.WriteLine(timeEnd - timeStart);

            IWebElement element = FindElement(driver, selector);
            ScrollTo(driver, element);
            element.Click();
        }

        public static void DoubleClick(this IWebDriver driver, By selector)
        {
            WaitForElementVisible(driver, selector);
            var actions = new Actions(driver);
            actions.DoubleClick(FindElement(driver, selector)).Perform();
        }

        public static void RightClick(this IWebDriver driver, By selector)
        {
            var actions = new Actions(driver);
            actions.ContextClick(FindElement(driver, selector)).Perform();
        }

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            var _js = (IJavaScriptExecutor)driver;
            _js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
        }

        public static void FillInput(this IWebDriver driver, By selector, string value)
        {
            IWebElement element = FindElement(driver, selector);
            ScrollTo(driver, element);
            element.SendKeys(value);
        }

        public static void ClickElement(this IWebDriver driver, By selector)
        {
            IWebElement element = FindElement(driver, selector);
            ScrollTo(driver, element);
            element.Click();
        }

        public static void SelectDefinedElement(this IWebDriver driver, By selector, string value)
        {
            var elements = new SelectElement(FindElement(driver, selector));
            elements.SelectByText(value);
        }

    }
}
