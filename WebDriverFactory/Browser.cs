using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EMagTest.WebDriverFactory
{
    public static class Browser
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        
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
                    _driver = new ChromeDriver(Path.GetFullPath(@"../../../" + @"Resources\ChromeDriver"));
                    break;
            }
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public enum BrowserName
        {
            Chrome,
            Firefox,
            Edge
        }

        public static void  Loadpage(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
        }

        public static void Close()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
