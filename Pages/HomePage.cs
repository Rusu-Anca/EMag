
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EMagTest.Pages
{

    public class HomePage : PageBase
    {
        public By logo_locator => By.CssSelector("[title='eMAG - Libertate în fiecare zi']");

        public By acceptCokkies_locator => By.ClassName("js-accept");
        public By closeOfertaZIlei_locator => By.ClassName("close");

        public By dismissLoghinBtn_locator => By.CssSelector(".container .js-dismiss-login-notice-btn"); //".js-dismiss-login-notice-btn .em-close");

        public By intraInContBtn_location => By.CssSelector(".content-wrap~a");

        public By widgetBenefits_locator => By.CssSelector(".widget-benefits-item>a span:last-child");

        public By toolTipPane_locator => By.CssSelector(".widget-benefits-tooltip>.ph-dropdown-inner");
        public By toolTipLink_locator => By.LinkText("Vezi mai multe detalii");

        public By BannerLogInButton_locator => By.ClassName(".js-login-btn");

        public By BannerCarouselDots_locator => By.CssSelector(".home-intro-section .banner-carousel .ph-dots a");

        public By CarouselLeftArrow_locator => By.CssSelector(".banner-carousel>.ph-arrows>.ph-left-margin");
        public By CarouselRightArrow_locator => By.CssSelector(".banner-carousel>.ph-arrows>.ph-right-margin");



        public By IFrameList_locator => By.CssSelector(".js-dfp-slide-item iframe");

        public string OfertaZileiIFrame_ID = "google_ads_iframe_/296121929/Slider_Home_2_0"; //"google_ads_iframe_/296121929/Slider_Home_Mbl_2_0";

        public By IFrameLink_locator => By.CssSelector(".GoogleActiveViewElement>a");

        // iframe id= "google_ads_iframe_/296121929/Slider_Home_6_0" -> link: https://www.emag.ro/campaign/deschide-romania?eaid=5719706328&eadv=172483369&ebuy=2871445592&ecid=138353016291&epid=300760489&esid=295122049&position=hp_slot_6&ref=dfp_5719706328"



        /*  public HomePage(IWebDriver driver) : base(driver)
          {
          }

          */

        public bool AssertTitle(string expected) => Browser.PageTitleContains(expected);


        public void AcceptCookies() => Browser.ClickWebElement(acceptCokkies_locator);

        public void NavigateHome() => Browser.ClickWebElement(logo_locator);

        public void ClickOnToolTipLink() => Browser.ClickWebElement(toolTipLink_locator);

        public void CloseOfertaZilei() => Browser.ClickWebElement(closeOfertaZIlei_locator);

        /// <summary>
        /// Dismiss the Login notice.
        /// </summary>
        public void DismissLoghinNoticeBtn()
        {
            Browser.ClickWebElement(dismissLoghinBtn_locator);
        }

        public void IntraInContButton() => Browser.ClickWebElement(intraInContBtn_location);

        /// <summary>
        /// Click on the Login button displayed on the banner.
        /// </summary>
        public void NavigateToLoginPage() => Browser.ClickWebElement(BannerLogInButton_locator);

        /// <summary>
        /// Dismiss all banners & alerts.
        /// </summary>
        public void DismissOfertaZileAndAcceptCookies()
        {
            Thread.Sleep(500);
            CloseOfertaZilei();
            AcceptCookies();
            DismissLoghinNoticeBtn();
        }

        /// <summary>
        /// Identify the benefit you want to hover over from the list of benefits.
        /// </summary>
        /// <param name="benefitName">The benefit you want to hover over.</param>
        public void HoverOverBenefitsElement(string benefitName)
        {
            IReadOnlyCollection<IWebElement> benefitsList = Browser.FindElements(widgetBenefits_locator);

            foreach (IWebElement elem in benefitsList)
            {
                if (elem.Text.Equals(benefitName))
                {
                    Browser.Current.ActionsMouseHover(elem);
                    break;
                }
            }
        }


        /// <summary>
        /// Identify the benefit you want to click on within the list of benefits, and click on it.
        /// </summary>
        /// <param name="benefitName">The benefit you want to click on.</param>
        public void ClickOnBenefitsElement(string benefitName)
        {
            IReadOnlyCollection<IWebElement> benefitsList = Browser.FindElements(widgetBenefits_locator);

            foreach (IWebElement elem in benefitsList)
            {
                if (elem.Text.Contains(benefitName))
                {
                    elem.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Go through the tool tip elements list, and if the searched element is displayed return true, else False.
        /// </summary>
        /// <param name="tooltipText">The text the tool tip info pane displayes.</param>
        /// <returns>True or False.</returns>
        public bool CheckToolTipIsDisplayed(string tooltipText)
        {
            bool result = false;

            IReadOnlyCollection<IWebElement> tooltips = Browser.FindElements(toolTipPane_locator);

            foreach (IWebElement toolTip in tooltips)
            {
                Console.WriteLine(toolTip.Text);
                if (toolTip.Text.Contains(tooltipText))
                {
                    // Console.WriteLine(toolTip.Text);
                    result = toolTip.Displayed;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Click on the Dots that control the displayed frame on the carousel.
        /// </summary>
        /// <param name="index">Is the  dot's index, within the list. that you want to click.</param>
        public void CarouselDotsClick(int index)
        {
            IList<IWebElement> dots = Browser.Current.FindElements(BannerCarouselDots_locator);

            dots[index].Click();
        }

        public void CarouselLeftArrowClick() => Browser.ClickWebElement(CarouselLeftArrow_locator);
        public void CarouselRightArrowClick() => Browser.ClickWebElement(CarouselRightArrow_locator);

        /// <summary>
        /// Switch to Oferta Zilei IFrame.
        /// </summary>
        public void SwitchToIFrame() => Browser.SwitchTo(OfertaZileiIFrame_ID);

        /// <summary>
        /// Click on IFrame from the carousel to navigate to it's page.
        /// </summary>
        public void ClickOnIframeLink() => Browser.ClickWebElement(IFrameLink_locator);



    }
}
