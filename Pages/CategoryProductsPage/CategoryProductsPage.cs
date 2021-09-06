using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.CategoryProductsPage
{
    class CategoryProductsPage: PageActions
    {

        public CategoryProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public By activeFilters_locator => By.CssSelector(".has-floating-listing-panel-footer> .listing-active-filters-holder:nth-of-type(4) .control-label");//.has-floating-listing-panel-footer> .listing-active-filters-holder:nth-of-type(4) .header-filter-item 
        //.has-floating-listing-panel-footer .listing-grid-group-scroller-outer

        //get text

        /// <summary>
        /// 
        /// </summary>
        public bool CheckActiveFilterHeader(string filterName)
        {
            bool result = false;
            IReadOnlyCollection<IWebElement> activeFilter = driver.FindElements(activeFilters_locator,20);
            foreach(IWebElement filter in activeFilter)
            {
                Console.WriteLine(filter.Text);
                if (filter.Text.Contains(filterName))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
