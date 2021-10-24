using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
   public class UserMenuBar : PageBase
    {
/*
        public UserMenuBar(IWebDriver driver) : base(driver)
        {
        }
*/
        public By myAccount_locator => By.CssSelector("#my_account .ini");
        public By myFavorites_locator => By.Id("my_wishlist");
        public By myCart_locator => By.Id("my_cart");
        public By intraInCont_locator => By.LinkText("Intra in cont");
        public By accountName_locator => By.CssSelector(".navbar-account-dropdown .ph-dropdown-inner p");



        public void NavigateTologInPage()
        {         
            Browser.Current.ActionsMouseHover(Browser.FindElement(myAccount_locator));
            Browser.ClickWebElement(intraInCont_locator);
        }

        public FavoritesPage NavigateToFavorites()
        {
            Browser.ClickWebElement(myFavorites_locator);
            return new FavoritesPage();
        }

        public CosulMeuPage NavigateToCARTPage()
        {
            Browser.ClickWebElement(myCart_locator);
            return new CosulMeuPage();
        }

        public bool CheckAccountName(string accountName)
        {
            Browser.Current.ActionsMouseHover(Browser.FindElement(myAccount_locator));
            return Browser.FindElement(accountName_locator).Text.Equals(accountName);
        }
    }
}
