using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EMagTest.Pages.MyAccount
{
    public class ContulMeuPage : PageBase
    {

        public By panelHeader_locator => By.CssSelector(".user-dashboard-slot .widget-title");

        public By panelFooter_locator => By.CssSelector(".row .panel-footer a");

        public By punctRidicareDesciption_locator => By.CssSelector(".pickup_point-slot .point-name");

        public By evalueazaExperientaNota_locator => By.ClassName("answers-col");
        public By userFeedbackMessage_locator => By.CssSelector(".user-feedback-form>div:nth-of-type(2) textarea");

        public By punctRidicareDropdown_judet => By.CssSelector(".col-xs-6 div.js-ls-region");

        public By select_judet => By.Id("mb-ls-county");

        public By judetOption => By.CssSelector(".ph-visible.ph-popup-s div[class='ph-select-options'] .ph-body a");


        public By punctRidicareDropdown_localitate => By.CssSelector(".col-xs-6 div.js-ls-city");

        public By select_localitate => By.Id("mb-ls-city");

        public By punctRidicare => By.CssSelector(".mb-map-point-panel-container .js-overflowed-panel li");

        public By saveButton_punctRidicareFavorit => By.ClassName("js-select-favorite-point");

        public By inapoiLaListaButton => By.ClassName("mb-map-point-details-back");

        public By avatarLocator => By.CssSelector(".user-avatar .picture");

        public By editAvatarButton => By.ClassName("js-edit-avatar");

        public By avatarUpload_locator => By.CssSelector(".hidden .js-avatar-uploader"); //.edit-avatar .hidden input

        public By avatarResizeKnob => By.ClassName("knob");

        public By SaveAvatarButton => By.ClassName("js-save");

        public By deleteAvatar => By.ClassName("js-avatar-delete");

        /// <summary>
        /// Iterate through the list of panels header that are displayed on the Contul Meu page, 
        /// and check if the expected card title is displayed. 
        /// </summary>
        /// <param name="cardTitle">The title of each card/pane displayed on the page.</param>
        public bool MyAccountPanelsHeaderIsDisplayed(string cardTitle)
        {
            IReadOnlyCollection<IWebElement> cardsTitleList = Browser.FindElements(panelHeader_locator);
            return WebElementsHelperMethods.ElementInTheListIsDisplayed(cardsTitleList, cardTitle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nota"></param>
        public void SelectNota(string nota)
        {
            IReadOnlyCollection<IWebElement> note = Browser.FindElements(evalueazaExperientaNota_locator);
            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(note, nota);
        }

        public bool PlaceholderIsDisplayed(string expected) => Browser.FindElement(userFeedbackMessage_locator).Text.Equals(expected);

        public void InputFeedbackMessage(string message) => Browser.FindElement(userFeedbackMessage_locator).EnterText(message);

        /// <summary>
        /// Click on the desired link from the panels displayed on the Contul Meu page.
        /// </summary>
        /// <param name="link">The link name.</param>
        /// <returns>The page.</returns>
        public DatePersonalePage ClickOnPanelLink(string link)
        {
            IReadOnlyCollection<IWebElement> panelLinkList = Browser.FindElements(panelFooter_locator);
            WebElementsHelperMethods.ClickOnCollectionElementIfMatches(panelLinkList, link);
            return new DatePersonalePage();
        }

        public bool CheckPunctRidicareFavoritPanelDetails(string description) => Browser.FindElement(punctRidicareDesciption_locator).Text.Contains(description);


        /// <summary>
        /// Click on the Judet dropdown.
        /// </summary>
        public void ClickOnJudetDropdown() => Browser.ClickWebElement(punctRidicareDropdown_judet);

        /// <summary>
        /// Click on Localitate dropdown.
        /// </summary>
        public void ClickOnLocalitateDropdown() => Browser.ClickWebElement(punctRidicareDropdown_localitate);

        /*/// <summary>
        /// Select an option form the Judet dropdown.
        /// </summary>
        /// <param name="judetul">The name of the Judet.</param>
        public void SelectJudetul(string judetul)
        {
            Browser.FindElement(select_judet).SelectByText(judetul);
        }
        */

        /*/// <summary>
        /// Select an option form the Localitate dropdown.
        /// </summary>
        /// <param name="localitatea">The name of the Localitate.</param>
        public void SelectLocalitatea(string localitatea)
        {
            Browser.FindElement(select_localitate).SelectByText(localitatea);
        }
        */

        /// <summary>
        /// Iterate through the Punct Ridicare List, scroll to it and click it.
        /// </summary>
        /// <param name="punctRidicareName">The name of the Punct Ridicare.</param>
        public void ClickOnPunctRidicare(string punctRidicareName)
        {
            IReadOnlyCollection<IWebElement> punctRidicareList = Browser.FindElements(punctRidicare);
            WebElementsHelperMethods.ScrollAndClickOnCollectionElementIfMatches(punctRidicareList, punctRidicareName);
        }
        /// <summary>
        /// Itareate through the list of options displayed, match the desired option, scroll it into view and click on it.
        /// </summary>
        /// <param name="optionName">The name of the option.</param>
        public void SelectJudetLocalitateOption(string optionName)
        {
            IReadOnlyCollection<IWebElement> judetOptionList = Browser.FindElements(judetOption);
            WebElementsHelperMethods.ScrollAndClickOnCollectionElementIfMatches(judetOptionList, optionName);
        }
        public void ClickOnSavePunctRidicare() => Browser.ClickWebElement(saveButton_punctRidicareFavorit);

        public void ClickOnInapoiLaListaButton()
        {
            IWebElement element = Browser.FindElement(inapoiLaListaButton);
            if (element.IsDisplayed("inapoiLaListaButton"))
            {
                element.Click();
            }

        }

        public void SelectPunctRidicareFavorit(string judetul, string localitatea, string punctRidicareName)
        {
            ClickOnJudetDropdown();
            SelectJudetLocalitateOption(judetul);
            ClickOnLocalitateDropdown();
            SelectJudetLocalitateOption(judetul);
            Thread.Sleep(500);
            ClickOnPunctRidicare(punctRidicareName);
            Thread.Sleep(500);
            ClickOnSavePunctRidicare();
        }

        public void ClickOnEditAvatarButton() => Browser.ClickWebElement(editAvatarButton);

        public void UploadAvatar(string photoName)
        {
            Browser.FindElement(avatarUpload_locator).SendKeys(@$"C:\Users\ancuta.rusu\source\repos\EMag\TestDataAccess\Photos\{photoName}.jpg");
            Browser.ChangeAttributeValue(avatarResizeKnob, "style", "left: 10.0402%;");
        }

        public void DeleteAvatar()
        {
            ClickOnEditAvatarButton();
            Browser.ClickWebElement(deleteAvatar);
        }

        /// <summary>
        /// Check if the list of avatars displayed contains 2 elements (1 on the Contul meu page & 1 on the Menu bar).
        /// </summary>
        /// <returns>True if the list contains both avatars, false otherwise.</returns>
        public bool CheckAvatarIsDisplayed()
        {
            IReadOnlyCollection<IWebElement> avatarIconList = Browser.FindElements(avatarLocator);
            Console.WriteLine(avatarIconList.Count);
            return avatarIconList.Count == 2;
        }

    }
}
