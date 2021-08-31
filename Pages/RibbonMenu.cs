using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    class RibbonMenu : PageActions
    {

        public RibbonMenu(IWebDriver driver) : base(driver)
        {
        }

        public By MainMenu_locator => By.ClassName("em-burger");
        public By productsDepartment_locator => By.ClassName("js-megamenu-list-department-link"); 


        public void ClickOnMenuANDSubmenu(string expected)
        {
           // driver.FindElement(MainMenu_locator,10).Click();

            IList<IWebElement> menu_list = driver.FindElements(productsDepartment_locator);

            foreach (IWebElement menuElement in menu_list)
            {
                if (menuElement.Text.Equals(expected))
                {
                    menuElement.Click();
                    break;
                }
            }

        }


    }
}
