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


        public bool ProductIsDisplayedInFavoritesPage(string productName)
        {
            IReadOnlyCollection<IWebElement> cardContainer = Browser.FindElements(cardContainer_locator);
            return WebElementsHelperMethods.ElementInTheListIsDisplayed(cardContainer, productName);
        }

    }


}
