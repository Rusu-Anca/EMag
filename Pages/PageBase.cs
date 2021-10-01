using EMagTest.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace EMagTest
{
    public class PageBase
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public int timeout;
       
        public PageBase(IWebDriver driver) 
        {
           this.driver = driver;
        }
        public void LoadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public bool PageTitleContains(string pageTitleString)
        {
            Console.WriteLine(driver.Title);
            return driver.Title.Contains(pageTitleString);
        }

        public void Refresh() => driver.Navigate().Refresh();

        public void SwitchTo(string id) => driver.SwitchTo().Frame(id);

        public string GetPageURL()
        {
            return driver.Url;
        }

    }
}
