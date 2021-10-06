using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.CategoryProductsPage
{
    public class SideFilter : PageBase
    {

      /*  public SideFilter(IWebDriver driver) : base(driver)
        {
        }
      */
        public By sideFilterHeader_locator => By.CssSelector(".filter-default  .filter-head");

        public By disponibilitateFilterOptions_locator => By.CssSelector(".filter-default #js-filter-6407-collapse a");

        public By eMagGeniusFilter_locator => By.XPath("//*[@data-filter-id='9538']//*[@class='filter-name']");
        public By eMagGeniusFilterOptions_locator => By.CssSelector("#js-filter-9538-collapse .filter-body a");

        public By stergeToateFiltrele_locator => By.CssSelector(".js-filter-status-holder .has-delete");

        public By brandFilterOptions_locator => By.CssSelector("div#js-filter-6415-collapse a");



        public void ExpandEMagFilter() => Browser.ClickWebElement(eMagGeniusFilter_locator);

        /// <summary>
        /// Search within the filters header list for a filter and expand or collapse the filter to view/hide options.
        /// </summary>
        /// <param name="filterName"></param>
        public void ExpandCollapseFilter(string filterName)
        {
            IReadOnlyCollection<IWebElement> filterList = Browser.FindElements(sideFilterHeader_locator);
            foreach (IWebElement filter in filterList)
            {
                if (filter.Text.Contains(filterName))
                {
                    filter.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Identifies the desired filter option within the options list, and checks if it is displayed or not.
        /// </summary>
        /// <param name="filterOption">The option name that is/is not displayed. </param>
        /// <returns>True if the option is displayed, false otherwise.</returns>
        public bool FilterOptionsDisplayed(string filterOption)
        {
            bool result = false;
            IReadOnlyCollection<IWebElement> eMagGeniusFilters = Browser.FindElements(eMagGeniusFilterOptions_locator);
            foreach (IWebElement filter in eMagGeniusFilters)
            {
                Console.WriteLine(filter.Text);
                if (filter.Text.Contains(filterOption))
                {

                    filter.SelectElement();
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Tick a filter option from the EMagGenius Filter section.
        /// </summary>
        /// <param name="filterOption">It's the filter option's name that is ticked.</param>
        public void SelectEmagGeniusFilter(string filterOption)
        {
            IReadOnlyCollection<IWebElement> eMagGeniusFilters = Browser.FindElements(eMagGeniusFilterOptions_locator);
            foreach (IWebElement filter in eMagGeniusFilters)
            {
                Console.WriteLine(filter.Text);
                if (filter.Text.Contains(filterOption))
                {

                    filter.SelectElement();
                    break;
                }
            }
        }

        public void SelectDisponibilitateFilter(string disponibilitateFilter)
        {
            IReadOnlyCollection<IWebElement> filterList = Browser.FindElements(disponibilitateFilterOptions_locator);
            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(filterList, disponibilitateFilter);
        }

        public void StergeToateFiltrele() => Browser.ClickWebElement(stergeToateFiltrele_locator);


        /// <summary>
        /// Scroll to a Brand filter option and select it.
        /// </summary>
        public void ScrollAndSelectBrandFilter(string brandNameFilter)
        {
            IReadOnlyCollection<IWebElement> brandFilters = Browser.FindElements(brandFilterOptions_locator);
            foreach (IWebElement filter in brandFilters)
            {
                Console.WriteLine(filter.Text);
                if (filter.Text.Contains(brandNameFilter))
                {
                    Browser.Current.ActionsMouseHover(filter);
                    filter.Click();
                    break;
                }
            }

        }
    }
}
