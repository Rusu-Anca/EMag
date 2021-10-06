using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public class SideMenu : PageBase
    {

       /* public SideMenu(IWebDriver driver) : base(driver)
        {
        }
       */
        public By sideMenuElementsList_locator => By.CssSelector(".emg-aside-links li");
        public By sideMenuLaptopCateg_locator => By.XPath("//*[@class='emg-aside-links']/li[1]/a");  //.sidebar-tree-subdepartment .sidebar-tree-item" 



        public void ClickOnProductCategorySideMenu(string expectedCategory)
        {
            IReadOnlyCollection<IWebElement> productCategoryList = Browser.FindElements(sideMenuElementsList_locator);

            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(productCategoryList, expectedCategory);

        }

        public void ClickOnLaptopCategory() => Browser.ClickWebElement(sideMenuLaptopCateg_locator);

    }
}
