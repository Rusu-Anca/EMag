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
        public By myWishList_locator => By.Id("my_wishlist");
        public By myCart_locator => By.Id("my_cart");
        public By intraInCont_locator => By.LinkText("Intra in cont");
        public By accountName_locator => By.CssSelector(".navbar-account-dropdown .ph-dropdown-inner p");



        public void NavigateTologInPage()
        {         
            Browser.Current.ActionsMouseHover(Browser.Current.FindElement(myAccount_locator));
            Browser.ClickWebElement(intraInCont_locator);
        }

        public void NavigateToWishListPage() => Browser.ClickWebElement(myCart_locator);

        public void NavigateToCARTPage() => Browser.ClickWebElement(myCart_locator);

        public bool CheckAccountName(string accountName)
        {
            Browser.Current.ActionsMouseHover(Browser.Current.FindElement(myAccount_locator, 5, displayed:true));
            return Browser.FindElement(accountName_locator).Text.Equals(accountName);
        }
    }
}
