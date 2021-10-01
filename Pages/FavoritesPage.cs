using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    class FavoritesPage 
    {

        public readonly FavoritesPageMap Map;

       
        public FavoritesPage(IWebDriver driver)
        {
            Map = new FavoritesPageMap(driver);
        }

       


       public class FavoritesPageMap
        {
            IWebDriver driver;
            public FavoritesPageMap(IWebDriver driver)
            {
                this.driver = driver;
            }

            public By cardContainer_locator => By.ClassName("card-container");

            public IReadOnlyCollection<IWebElement> cardContainer => driver.FindElements(cardContainer_locator);
        }



    }
}
