using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.MyAccount
{
    public class DatePersonalePage: PageBase
    {

        public DatePersonalePage()
        {
        }

        //Datele Mele

        public By formaAdresare_locator(string gender) => By.CssSelector($"#accountGender{gender}+label");

        public void SelectFormaDeAdresare(string gender) => Browser.ClickWebElement(formaAdresare_locator(gender));
    }
}
