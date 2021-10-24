using EMagTest.HelperMethods;
using EMagTest.TestSuite.Base;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public class CosulMeuPage : TestBase
    {
        public By productCard => By.ClassName("cart-vendor-container");

        public By productTitle => By.CssSelector(".main-product-title-container");

        /// <summary>
        /// Check if the product is displayed in the Cart page.
        /// </summary>
        /// <param name="productName">The product name that was added to cart.</param>
        /// <returns>True if it is displayed, False otherwise.</returns>
        public bool ProductDisplayed(string productName)
        {
            IReadOnlyCollection<IWebElement> productsList = Browser.FindElements(productTitle);
            return WebElementsHelperMethods.ElementInTheListIsDisplayed(productsList, productName);

        }

    }
}
