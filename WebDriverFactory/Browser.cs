using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EMagTest.WebDriverFactory
{
    public static class Browser
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        /// <summary>
        /// Browser factory, opens the desired browser.
        /// </summary>
        /// <param name="browser">The browser you want to use.</param>
        public static void Init(BrowserName browser)
        {
            switch (browser)
            {
                case BrowserName.Edge:
                    _driver = new EdgeDriver(Path.GetFullPath(@"../../../" + @"Resources\EdgeDriver"));
                    break;

                case BrowserName.Firefox:
                    _driver = new FirefoxDriver(Path.GetFullPath(@"../../../" + @"Resources\FireFoxDriver"));
                    break;
                case BrowserName.Chrome:
                    _driver = new ChromeDriver(Path.GetFullPath(@"../../../" + @"Resources\ChromeDriver1"));
                    break;
            }
        }

        /// <summary>
        /// Get the current driver instance.
        /// </summary>
        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public enum BrowserName
        {
            Chrome,
            Firefox,
            Edge
        }

        /// <summary>
        /// Navigate to a specific page..
        /// </summary>
        /// <param name="URL">The page URL.</param>
        public static void GoTo(string URL)
        {
            Debug.WriteLine(URL);
            _driver.Navigate().GoToUrl(URL);

        }

        /// <summary>
        /// Maximise the borwser window.
        /// </summary>
        public static void WindowMaximize() => _driver.Manage().Window.Maximize();

        /// <summary>
        /// Close all browsers instances.
        /// </summary>
        public static void Close()
        {
            _driver.Close();
            _driver.Quit();
        }

        /// <summary>
        /// Refresh the page.
        /// </summary>
        public static void Refresh() => _driver.Navigate().Refresh();

        /// <summary>
        /// Switch to the iFrame id.
        /// </summary>
        /// <param name="id">The ID of the frame.</param>
        public static void SwitchTo(string id) => _driver.SwitchTo().Frame(id);

        /// <summary>
        /// Obtain the page URL
        /// </summary>
        /// <returns>URL of the page.</returns>
        public static string GetPageURL() => _driver.Url;

        /// <summary>
        /// Check that the page has correct title.
        /// </summary>
        /// <param name="pageTitleString"></param>
        /// <returns></returns>
        public static bool PageTitleContains(string pageTitleString)
        {
            Console.WriteLine(_driver.Title);
            return _driver.Title.Contains(pageTitleString);
        }

        /// <summary>
        /// Obtain the page title.
        /// </summary>
        /// <returns>The page title.</returns>
        public static string GetPageTitle() => _driver.Title;

        /// <summary>
        /// Wait for the page to be loaded.
        /// </summary>
        /// <param name="timeout">The Time to wait.</param>
        public static void LoadComplete(int timeout)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Switch to an alert and dismiss it.
        /// </summary>
        public static void DismissAlert() => _driver.SwitchTo().Alert().Dismiss();

        /// <summary>
        /// Scroll to an element so that it is in view.
        /// </summary>
        /// <param name="by">By.</param>
        public static void ScrollToElement(By by)
        {
            var e = _driver.FindElement(by);
            ((IJavaScriptExecutor)_driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", e);

        }

        /// <summary>
        /// Click on a web element.
        /// </summary>
        /// <param name="by">By.</param>
        public static void ClickWebElement(By by)
        {
            _driver.FindElement(by, 5, displayed: true).Click();
        }

        /// <summary>
        /// Find a webelement by By.
        /// </summary>
        /// <param name="by">By.</param>
        /// <returns>The webelement.</returns>
        public static IWebElement FindElement(By by) => Current.FindElement(by, 10, displayed: true);

        /// <summary>
        /// Find a collection of webelements by By.
        /// </summary>
        /// <param name="by">By.</param>
        /// <returns>The collection of webelements.</returns>
        public static IReadOnlyCollection<IWebElement> FindElements(By by) => Current.FindElements(by, 10);
    }
}
