using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.MyAccount
{
    public class DatePersonalePage : PageBase
    {

        public DatePersonalePage()
        {
        }

        //Datele Mele

        public By formaAdresare_locator(string gender) => By.CssSelector($"input[id='accountGender{gender}");

        public By nickname_locator => By.CssSelector("input[name='nickname']");

        public By telefonFix_locator => By.CssSelector("input[name = 'telephone2']");

        public By dropdown_locator => By.CssSelector(".gui-form-row .select2-selection--single");
        public By yearDropDown => By.Id("select2-anul-cc-container");

        public By search => By.CssSelector(".select2-search--dropdown input");

        public By monthDropDown => By.Id("select2-luna-yh-container");

        public By dayDropDown => By.Id("select2-ziua-qz-container");
        public By educatieDropDown => By.CssSelector("span[aria-labelledby='select2-nivel_educatie-container']");

        public By dropdownOption => By.ClassName("select2-results__option");

        public By salveazaButton => By.CssSelector("#detailsForm .btn-save-details");
        public By dateleMelel_labelDetails => By.CssSelector(".gui-label+.details-display");

        /// <summary>
        /// Select forma de adresare radio button.
        /// </summary>
        /// <param name="gender">The gender you want to select.</param>
        public void SelectFormaDeAdresare(string gender) => Browser.FindElement(formaAdresare_locator(gender)).SelectRadioButton();

        /// <summary>
        /// Iterate throgh the list of dorpdown buttons displayed on the page, and click on the desired dropdown.
        /// </summary>
        /// <param name="attribute">The attribute of the dropdown element.</param>
        /// <param name="dropdownName">The name of the dropdown on which it clicks.</param>
        public void ClickonDropDown(string attribute, string dropdownName) //aria-labelledby , 
        {
            IReadOnlyCollection<IWebElement> dropDownList = Browser.FindElements(dropdown_locator);
            WebElementsHelperMethods.ClickOnCollectionElementIfAttributeMatches(dropDownList, attribute, dropdownName);
        }

        /// <summary>
        /// Input a text in the NickName field.
        /// </summary>
        /// <param name="nickName">The nickname.</param>
        public void FillInNicknameField(string nickName) => Browser.FindElement(nickname_locator).EnterText(nickName);

        /// <summary>
        /// Input phone no in the TelefonFix field.
        /// </summary>
        /// <param name="telefonFix">The phone no.</param>
        public void FillInTelefonFixField(string telefonFix) => Browser.FindElement(telefonFix_locator).EnterText(telefonFix);

       /// <summary>
       /// Input some text in the Search field.
       /// </summary>
       /// <param name="text">The text to be filled in.</param>
        public void FillInSearchField(string text) => Browser.FindElement(search).SendKeys(text);

        /// <summary>
        /// Press Enter key to select the desired element from the drop down options.
        /// </summary>
        public void EnterSearchedString() => Browser.FindElement(search).SendKeys(Keys.Enter);

        /// <summary>
        /// Select any option from the day/month/year dropdown panel.
        /// </summary>
        /// <param name="optionName">The option name.</param>
        public void SelectDropdownOption(string optionName)
        {
            IReadOnlyCollection<IWebElement> dropdownOptions = Browser.FindElements(dropdownOption);
            WebElementsHelperMethods.ScrollAndClickOnCollectionElementIfMatches(dropdownOptions, optionName);

        }

        /// <summary>
        /// Select a specific year from the year dropdown panel.
        /// </summary>
        /// <param name="year">The year you want to select.</param>
        public void SelectYear(string year)
        {
            ClickonDropDown("aria-labelledby", "anul");
            FillInSearchField(year);
            EnterSearchedString();
        }

        /// <summary>
        /// Select a specific month from the dropdown panel.
        /// </summary>
        /// <param name="month">The month you want to select.</param>
        public void SelectMonth(string month)
        {
            ClickonDropDown("aria-labelledby", "luna");
            SelectDropdownOption(month);
        }

        /// <summary>
        /// Select a specific education level from the dropdown panel.
        /// </summary>
        /// <param name="educatie">The education lavel you want to select.</param>
        public void SelectEducatie(string educatie)
        {
            ClickonDropDown("aria-labelledby", "educatie");
            SelectDropdownOption(educatie);
        }

        /// <summary>
        /// Select a specific day from the dropdown panel.
        /// </summary>
        /// <param name="day">The day you want to select.</param>
        public void SelectDay(string day)
        {
            ClickonDropDown("aria-labelledby", "ziua");
            FillInSearchField(day);
            EnterSearchedString();
        }

        /// <summary>
        /// Click on Salveaza button.
        /// </summary>
        public void ClickSalveazaButton() => Browser.ClickWebElement(salveazaButton);

        /// <summary>
        /// Fill in specific fields from the Datele Mele Form and Save it.
        /// </summary>
        /// <param name="nickName"></param>
        /// <param name="telefonFix"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="educatie"></param>
        public void FillInDateleMeleForm(string nickName, string telefonFix, string year, string month, string day, string educatie)
        {
            
            FillInNicknameField(nickName);
            FillInTelefonFixField(telefonFix);
            SelectYear(year);
            SelectMonth(month);
            SelectDay(day);
            SelectEducatie(educatie);
            ClickSalveazaButton();
        }


        /// <summary>
        /// Verifies if the details displayed on the Datele Mele panel are correct.
        /// </summary>
        /// <param name="labelDetails">The text displayed as the label.</param>
        /// <returns>True if the correct description is displayed, False otherwise.</returns>
        public bool CheckDateleMeleDetails(string labelDetails)
        {
            IReadOnlyCollection<IWebElement> labelDetailsList = Browser.FindElements(dateleMelel_labelDetails);
            return WebElementsHelperMethods.ElementInTheListIsDisplayed(labelDetailsList, labelDetails);
        }
    }
}
