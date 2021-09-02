using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.CategoryProductsPage
{
    class SideFilter : PageActions
    {

        public SideFilter(IWebDriver driver) : base(driver)
        {
        }

        public By eMagGeniusFilter_locator => By.XPath("//*[@data-filter-id='9538']//*[@class='filter-name']");
        public By eMagGeniusFilterOptions_locator => By.CssSelector("#js-filter-9538-collapse .filter-body a");

        public void ExpadEMagFilter() => driver.FindElement(eMagGeniusFilter_locator).Click();

        public void SelectEmagGeniusFilter(string filterOption)
        {
            IList<IWebElement> eMagGeniusFilters = driver.FindElements(eMagGeniusFilterOptions_locator);
            foreach (IWebElement filter in eMagGeniusFilters)
            {
                if (filter.Text.Equals(filterOption))
                {
                    filter.Click();
                    break;
                }
            }
        }
    }
}
