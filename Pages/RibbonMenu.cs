using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public class RibbonMenu : PageBase
    {
/*
        public RibbonMenu(IWebDriver driver) : base(driver)
        {
        }
*/
        public By MainMenu_locator => By.ClassName("navbar-aux-content__departments");
        public By productsDepartment_locator => By.ClassName("js-megamenu-list-department-link");


        public void HoverOnMenuClickSubmenuItem(string expected)
        {
            Browser.Current.ActionsMouseHover(Browser.Current.FindElement(MainMenu_locator, 10, displayed: true));

            IReadOnlyCollection<IWebElement> menu_list = Browser.FindElements(productsDepartment_locator);

            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(menu_list, expected);
                      
        }


    }
}
