using EMagTest.HelperMethods;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages.MyAccount
{
    public class ContulMeuPage : PageBase
    {
/*
        public ContulMeuPage(IWebDriver driver) : base(driver)
        {
        }
*/
        public By panelHeader_locator => By.CssSelector(".user-dashboard-slot .widget-title");

        public By panelFooter_locator => By.ClassName("panel-footer");

        public By evalueazaExperientaNota_locator => By.ClassName("answers-col");
        public By userFeedbackMessage_locator => By.CssSelector(".user-feedback-form>div:nth-of-type(2) textarea");


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
    }
}
