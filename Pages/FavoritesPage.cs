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

        public IReadOnlyCollection<IWebElement> cardContainer => Browser.FindElements(cardContainer_locator);
    }


}
