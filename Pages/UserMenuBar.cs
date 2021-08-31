using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    class UserMenuBar : PageActions
    {

        public UserMenuBar(IWebDriver driver) : base(driver)
        {
        }

        public By myAccount_locator => By.Id("my_account");
        public By myWishList_locator => By.Id("my_wishlist");
        public By myCart_locator => By.Id("my_cart");
        public By intraInCont_locator => By.LinkText("Intra in cont");



        public void NavigateTologInPage()
        {
         
            driver.ActionsMouseHover(driver.FindElement(myAccount_locator));
            driver.FindElement(intraInCont_locator).Click();
        }

        public void NavigateToWishListPage() => driver.FindElement(myCart_locator).Click();

        public void NavigateToCARTPage() => driver.FindElement(myCart_locator).Click();

        
    }
}
