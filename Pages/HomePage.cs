
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EMagTest.Pages
{

    public class HomePage : PageActions
    {
        // public IWebDriver driver;

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

        public string OfertaZileiIFrame_ID ="google_ads_iframe_/296121929/Slider_Home_2_0"; //"google_ads_iframe_/296121929/Slider_Home_Mbl_2_0";

        public By IFrameLink_locator => By.CssSelector(".GoogleActiveViewElement>a");

        // iframe id= "google_ads_iframe_/296121929/Slider_Home_6_0" -> link: https://www.emag.ro/campaign/deschide-romania?eaid=5719706328&eadv=172483369&ebuy=2871445592&ecid=138353016291&epid=300760489&esid=295122049&position=hp_slot_6&ref=dfp_5719706328"



        public HomePage(IWebDriver driver) : base(driver)
        {
        }


        public bool AssertTitle(string expected) => driver.Title.Equals(expected);
        public void AcceptCookies() => driver.FindElement(acceptCokkies_locator, 10).Click();
        public void ClickOnToolTipLink() => driver.FindElement(toolTipLink_locator, 5).Click();

        public void CloseOfertaZilei() => driver.FindElement(closeOfertaZIlei_locator, 10).Click();


        public void DismissLoghinNoticeBtn()
        {
            Thread.Sleep(1000);
            IWebElement dismissButon = driver.FindElement(dismissLoghinBtn_locator,10);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", dismissButon);
        }

        public void IntraInContButton() => driver.FindElement(intraInContBtn_location).Click();

        public void NavigateToLoginPage() => driver.FindElement(BannerLogInButton_locator).Click();

        public void DismissOfertaZileAndAcceptCookies()
        {
            Thread.Sleep(500);
            CloseOfertaZilei();
            AcceptCookies();
            DismissLoghinNoticeBtn();
        }

        public void HoverOverBenefitsElement(string benefitName)
        {
            IList<IWebElement> benefitsList = driver.FindElements(widgetBenefits_locator);

            foreach (IWebElement elem in benefitsList)
            {
                if (elem.Text.Equals(benefitName))
                {
                    driver.ActionsMouseHover(elem);
                    break;
                }
            }
        }

        public void ClickOnBenefitsElement(string benefitName)
        {
            IReadOnlyCollection<IWebElement> benefitsList = driver.FindElements(widgetBenefits_locator, 10);

            foreach (IWebElement elem in benefitsList)
            {
                if (elem.Text.Contains(benefitName))
                {
                    elem.Click();
                    break;
                }
            }
        }
        public bool CheckToolTipIsDisplayed(string tooltipText)
        {
            bool result = false;

            IList<IWebElement> tooltips = driver.FindElements(toolTipPane_locator);

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

        public void CountIFrames()
        {
            string iframeID = null;
            IReadOnlyCollection<IWebElement> iFrameList = driver.FindElements(IFrameList_locator, 10);
            foreach (IWebElement iframe in iFrameList)
            {
                if (iframe.IsDisplayed("IFrameList_locator"))
                {
                    iframeID = iframe.GetAttribute("id");
                    Console.WriteLine(iframeID);
                }
            }
        }

        public void CarouselDotsClick(int index)
        {
            IList<IWebElement> dots = driver.FindElements(BannerCarouselDots_locator);

            dots[index].Click();
        }

        public void CarouselLeftArrowClick() => driver.FindElement(CarouselLeftArrow_locator).Click();
        public void CarouselRightArrowClick() => driver.FindElement(CarouselRightArrow_locator).Click();

        public void SwitchToIFrame() => driver.SwitchTo().Frame(OfertaZileiIFrame_ID);

        public void ClickOnIframeLink() => driver.FindElement(IFrameLink_locator).Click();



    }
}
