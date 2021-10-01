using EMagTest.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EMagTest.Pages.CategoryProductsPage
{
    public class Product : PageBase
    {

        public Product(IWebDriver driver) : base(driver)
        {
        }

        public By productTitle_locator => By.CssSelector(".card-v2-info .pad-hrz-xs");

        public By productRating_locator => By.CssSelector("");

        public By productCard_locator => By.ClassName("card-v2-wrapper");

        public By productFavoriteBtn_locator => By.ClassName("add-to-favorites");

        public By favoriteConfirmationMessage_locator => By.ClassName("ns-wrap-top-right");

        public By addToCartButton_locator => By.ClassName("card-v2-atc");

        public By paginaUrmatoare_locator => By.CssSelector("#listing-paginator li:last-child a");

        public By addToCartConfirmationModal_locator => By.ClassName("modal-header");

        public By paginationButtons_locator => By.CssSelector("#listing-paginator li");


        /// <summary>
        /// Check if the title of each product on the page contains a specific value/string.
        /// </summary>
        /// <param name="expected">The value/string the produt title should contain.</param>
        /// <returns>True if it contains the expected value/text, False otherwise.</returns>
        public bool CheckProductsTitleContains(string expected)
        {
            int count = 0;
            IReadOnlyCollection<IWebElement> productsTitleList = driver.FindElements(productTitle_locator, 60);
            foreach (IWebElement title in productsTitleList)
            {
                if (!title.Text.Contains(expected))
                {
                    count += 1;
                }

            }

            return count == 0;
        }

        // <summary>
        /// Find the desired product within the products displayed on the page and 
        /// click on the Favorit button to be added to the Favorites list.
        /// </summary>
        /// <param name="productTitle">The title/name of the product we want to add to favorite list.</param>
        public void AddProductToFavoritesList(string productTitle)
        {
            IReadOnlyCollection<IWebElement> productsList = driver.FindElements(productCard_locator, 40);
            WebElementsHelperMethdos.ClickOnChildElement(productsList, productTitle, productFavoriteBtn_locator);
        }

        /// <summary>
        /// Check that the confirmation message for succesful adding a product to faorites list is displayed.
        /// </summary>
        /// <returns></returns>
        public bool FavoriteSuccessMessage() => driver.FindElement(favoriteConfirmationMessage_locator, 20, displayed: true).IsDisplayed("favoriteConfirmationMessage_locator");

        public void AddProductToCart(string productTitle)
        {
            IWebElement paginaUrmatoare = driver.FindElement(paginaUrmatoare_locator);
            IReadOnlyCollection<IWebElement> productsList = driver.FindElements(productCard_locator, 40);
            //WebElementsHelperMethdos.SearchElementOnPageUntilFound(productsList, productTitle, addToCartButton_locator, paginaUrmatoare);
        }

        public bool AddProductToMyCart(string productTitle)
        {

            bool count = false;
            while (count == false)
            {
                LoadComplete();
                IReadOnlyCollection<IWebElement> productsList = driver.FindElements(productCard_locator, 40);
                foreach (var product in productsList)
                {
                    //It seems that on debugging the test executes correctly, so I don't know how to insert a wait for the page to load
                    //after it navigates to the next page.
                    Console.WriteLine(product.Text);
                    if (product.Text.Contains(productTitle))
                    {
                        IWebElement childElem = product.FindElement(addToCartButton_locator);
                        childElem.Click();
                        count = true;
                        break;
                    }

                }
                Thread.Sleep(1000);
                IWebElement paginaUrmatoare = driver.FindElement(paginaUrmatoare_locator);
                if (count == false & paginaUrmatoare.HasAttribute("class", "js-change-page"))
                {
                    paginaUrmatoare.Click();
                }
            }

            return driver.FindElement(addToCartConfirmationModal_locator, 10, displayed: true).IsDisplayed("addToCartConfirmationModal_locator");
        }

        /// <summary>
        /// Iterate through the list of navigation buttons and check if it is enabled.
        /// NOTE!!! We are not using the Enabled property as the element doesn't have the disabled='disabled' attribute.
        /// </summary>
        /// <param name="buttonLabel">The Name of the button.</param>
        /// <returns>False if the button is enabled, True otherwise.</returns>
        public bool CheckNavigationButtonIsDisabled(string buttonLabel)
        {
            bool result = false;
            IReadOnlyCollection<IWebElement> paginationButtons = driver.FindElements(paginationButtons_locator);
            foreach (IWebElement paginationButton in paginationButtons)
            {
                if (paginationButton.Text.Contains(buttonLabel))
                {
                    result = paginationButton.GetAttribute("class").Contains("disabled");
                    break;
                }
            }
            return result;
        }


        public void ClickOnNavigationButton(string buttonLabel)
        {
            IReadOnlyCollection<IWebElement> paginationButtons = driver.FindElements(paginationButtons_locator, 20);
            WebElementsHelperMethdos.ClickOnCollectionElementIfMatches(paginationButtons, buttonLabel);
            
        }
    }
}
