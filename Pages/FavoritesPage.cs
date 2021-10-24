using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public class FavoritesPage : PageBase
    {

        public By cardContainer_locator => By.ClassName("card-container");

        public By cardHeader_locator => By.CssSelector("h2");

        public By adaugaInCos => By.CssSelector("[type='submit']");

        public By sterge => By.CssSelector(".remove-from-favorites");

        public By productAvailability => By.CssSelector(".favorite-product-availability");

        /// <summary>
        /// Check if the product added to favorites is acctually displayed in the Favorites page.
        /// </summary>
        /// <param name="productName">The name of the Product.</param>
        /// <returns></returns>
        public bool ProductIsDisplayedInFavoritesPage(string productName)
        {
            IReadOnlyCollection<IWebElement> cardContainer = Browser.FindElements(cardContainer_locator);
            return WebElementsHelperMethods.ElementInTheListIsDisplayed(cardContainer, productName);
        }

        /// <summary>
        ///Iterate through the products displayed in the Favorites list to check for a specific product & add it to Cart.
        /// </summary>
        /// <param name="productName">The name of the product.</param>
        public void AddProductToCart(string productName)
        {
            IReadOnlyCollection<IWebElement> cardContainer = Browser.FindElements(cardContainer_locator);
             WebElementsHelperMethods.ClickOnChildElement(cardContainer, productName, adaugaInCos);
        }

        /// <summary>
        /// Removes a product from Favorites list if the product is no longer In Stock.
        /// </summary>
        /// <param name="productName">The name of the product.</param>
        public void RemoveProductFromFavorites(string productName)
        {
            IReadOnlyCollection<IWebElement> cardContainer = Browser.FindElements(cardContainer_locator);
            foreach (var product in cardContainer)
            {
                Console.WriteLine(product.Text);
                if (product.Text.Contains(productName) & product.FindElement(productAvailability).Text.Contains("stoc epuizat"))
                {
                    IWebElement childElem = product.FindElement(sterge);
                    childElem.Click();
                    break;
                }
            }

        }

       

    }


}
