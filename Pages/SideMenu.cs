using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public class SideMenu : PageBase
    {

        public SideMenu(IWebDriver driver) : base(driver)
        {
        }

        public By sideMenuElementsList_locator => By.CssSelector(".emg-aside-links li");
        public By sideMenuLaptopCateg_locator => By.XPath("//*[@class='emg-aside-links']/li[1]/a");  //.sidebar-tree-subdepartment .sidebar-tree-item" 



        public void ClickOnProductCategorySideMenu(string expectedCategory)
        {
            IList<IWebElement> productCategoryList = driver.FindElements(sideMenuElementsList_locator);

            foreach (IWebElement productCateg in productCategoryList)
            {
                if (productCateg.Text.Equals(expectedCategory))
                {
                    productCateg.Click();
                    break;
                }
            }
        }

        public void ClickOnLaptopCategory() => driver.FindElement(sideMenuLaptopCateg_locator, 5, displayed: true).Click();

    }
}
