using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.CategoryProductsPage
{
    public class TopFilters : PageBase
    {
       /* public TopFilters(IWebDriver driver) : base(driver)
        {
        }*/

        public By activeFilters_locator => By.CssSelector(".listing-active-filters-holder .input-group-sm .js-filter-select a");

        public By staticFilters_locators => By.CssSelector(".has-floating-listing-panel-footer .listing-quick-filters-holder .ph-label"); //.has-floating-listing-panel-footer .listing-quick-filters-holder .input-group .ph-label

        public By filtersHeader_locator => By.CssSelector(".listing-grid-group-scroller-inner .header-filter-item");

        public By currentFilterSelection_locator => By.CssSelector(".ph-label");

        public By filterOptions_locator => By.CssSelector(".ph-visible .js-quick-filter-option");

        public By removeTopFilterOption_locator => By.CssSelector(" .input-group-btn");

        public By ordoneazaDropdown_locator => By.ClassName("sort-control-btn-dropdown");
        public By ordoneazaOptions_locator => By.CssSelector(".listing-sorting-dropdown li");


        /// <summary>
        /// Check that the selected filter is displayed on the page, within the active filters section.
        /// </summary>
        /// <param name="filterName">The name of the filter that we expect to be displayed.</param>
        /// <param name="index">The index of the filter, if more filters are selected.</param>
        /// <returns>True if the filter name is displayed, False otherwise.</returns>
        public bool CheckActiveFilterDisplay(string filterName, int index)
        {
            bool result = false;
            IList<IWebElement> activeFilter = Browser.Current.FindElements(activeFilters_locator);
            Console.WriteLine(activeFilter[index].Text);
            if (activeFilter[index].Text.Contains(filterName))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Check that the selected filter is displayed on the page, within the static filters section.
        /// </summary>
        /// <param name="filterName">The name of the filter that we expect to be displayed.</param>
        /// <returns>True if the filter name is displayed, False otherwise.</returns>
        public bool CheckStaticFilterDisplay(string filterName)
        {
            bool result = false;
            IReadOnlyCollection<IWebElement> staticFilter = Browser.FindElements(staticFilters_locators);
            foreach (IWebElement filter in staticFilter)
            {
                Browser.Current.ActionsMouseHover(filter);
                Console.WriteLine(filter.Text);
                if (filter.Text.Contains(filterName))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /*
         * Can't use this method as I get the Null reference exeption, and can't understand why.
        public bool StaticFilterDisplay(string filterName)
        {
           return  HelperMethods.HelperMethdos.ElementInTheListIsDisplayed(staticFilters_locators, filterName);
        }
        */

        /// <summary>
        /// Identify the desired filter within the list of top filters and click on the dropdown to view the available filter options.
        /// Note: this works for both static and active filters.
        /// </summary>
        /// <param name="filterHeaderName">The name of the filter for which you want to view the dropdownwith the filter options.</param>
        /// <returns>The name of the selected filter option, if any selected, otherwise returns the placeholder/default string.</returns>
        public string ClickDropdownFilterOption(string filterHeaderName)
        {
            string selectedFilter = null;
            IReadOnlyCollection<IWebElement> filtersHeaderList = Browser.FindElements(filtersHeader_locator);
            foreach (IWebElement filterHeader in filtersHeaderList)
            {
                if (filterHeader.Text.Contains(filterHeaderName))
                {
                    IWebElement filterdropdown = filterHeader.FindElement(currentFilterSelection_locator);
                    selectedFilter = filterdropdown.Text;
                    filterdropdown.Click();
                    break;
                }
            }
            return selectedFilter;
        }

        /// <summary>
        /// Identify the filter option you want to select from the options dropdown, and check it.
        /// NOTE: this can be used for selecting any option from any of the static filters (Brand/ Compatibilitate maxima laptop/ Tip).
        /// </summary>
        /// <param name="filterOptionName">The filter option you want to select.</param>
        /// <returns>The name of the selected filter option.</returns>
        public string SelectFilterOption(string filterOptionName)
        {
            string selectedFilters = null;
            IReadOnlyCollection<IWebElement> filterOptionsList = Browser.FindElements(filterOptions_locator);
            foreach (IWebElement filterOption in filterOptionsList)
            {
                Console.WriteLine(filterOption.Text);
                if (filterOption.Text.Contains(filterOptionName))
                {

                    selectedFilters = filterOption.Text;
                    filterOption.SelectRadioButton();
                    break;
                }

            }
            return selectedFilters;
        }

        /// <summary>
        /// Identify the desired filter within the list of top filters and click on the remove button displayed next to it, to 
        /// remove the filter option(s).
        /// Note: this works for both static and active filters.
        /// </summary>
        /// <param name="filterHeaderName">The name of the filter for which you want to remove the filter option(s).</param>
        public void ClickOnRemoveFilterOptionButton(string filterHeaderName)
        {
            IReadOnlyCollection<IWebElement> filtersHeaderList = Browser.FindElements(filtersHeader_locator);
            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(filtersHeaderList, filterHeaderName);
        }

        public void ClickOnOrdoneazaDropdown() => Browser.ClickWebElement(ordoneazaDropdown_locator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortOption"></param>
        public void SelectOrdoneazaOption(string sortOption)
        {
            IReadOnlyCollection<IWebElement> ordoneazaOptionList = Browser.FindElements(ordoneazaOptions_locator);
            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(ordoneazaOptionList, sortOption);

        }
    }

}

