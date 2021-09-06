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

        public By MainMenu_locator => By.ClassName("navbar-aux-content__departments");
        public By productsDepartment_locator => By.ClassName("js-megamenu-list-department-link");


        public void HoverOnMenuClickSubmenuItem(string expected)
        {
            driver.ActionsMouseHover(driver.FindElement(MainMenu_locator, 10, displayed: true));

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
