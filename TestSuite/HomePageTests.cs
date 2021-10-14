using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite
{
    class HomePageTests
    {
        public const string HomePage_Title = "eMAG.ro - Libertate în fiecare zi";
        public const string eMagGeniusPage_Title = "eMAG genius: serviciul tău premium de cumpărături - eMAG.ro";
        Dictionary<string, string> benefits_collection = new Dictionary<string, string> {
            { "eMAG Genius", "Bucură-te de cumpărături cu beneficii premium!" },
            {"easybox by eMAG","Comanzi când vrei, ridici când poți! În plus, poți să returnezi la easybox produsele care nu ți se potrivesc!" },
            {"Livrare în 1h","Bucură-te de livrări în super viteză cu Tazz by eMAG! În doar o oră, primești ce îți dorești din showroom, magazine sau restaurante!" },
            {"Cardul eMAG de la Raiffeisen Bank","Aplica acum! Ai până la 10% înapoi în puncte și până la 24 rate fara dobândă." },
            {"Dăruiește un voucher eMAG ","Fă-le o surpriză celor dragi și oferă-le un voucher cadou cu care să își cumpere exact ce își doresc!" }
        };
        public const string OfertaZileiPageTitle = "Oferta-zilei"; //  Oferta zilei / "Fier de calcat portabil Rowenta Tweeny Nano DV9000D1, Calcare verticala si orizontala, 950W, Rezervor detasabil 50ml, Autonomie 10min, Perie pentru tesaturi, Alb - eMAG.ro";
        public const string ProductCategory = "Laptopuri si accesorii";
        public const string ProductSubCategory = "Laptopuri";

        public const string SubMenu = "Laptop, Tablete & Telefoane";
        public const string LaptopPageTitle = "Laptopuri - eMAG.ro";

       
        /// <summary>
        /// Check you can close Oferta zilei alert & accept Cookie.
        /// </summary>
        [Test]
        public void AcceptCookiesTest()
        {
            // Thread.Sleep(500);
            PageWrapper.home.CloseOfertaZilei();
            PageWrapper.home.AcceptCookies();

        }

        /// <summary>
        /// Check you can also dismiss the Login banner.
        /// </summary>
        [Test]
        public void DismissLoginButtonTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
        }

        /// <summary>
        /// Check you can click on the EMag Genius Benefits link, and you are redirected to the correct page.
        /// </summary>
        [Test]
        public void EMagGeniusBenefitRedirectTest()
        {
            PageWrapper.home.ClickOnBenefitsElement(benefits_collection.Keys.ElementAt(0));
            Assert.AreEqual(Browser.GetPageTitle(), eMagGeniusPage_Title);

        }

        /// <summary>
        /// Dismisse Oferta zilei, and accept Cookies, then hover over the 
        /// eMag Genius benefit, and clicks on the Vezi mai multe detalii link and asserts the page title is correct.
        /// </summary>
        [Test]
        public void EMagGeniusBenefitToolTipLinkTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(0));
            PageWrapper.home.ClickOnToolTipLink();
            Assert.AreEqual(Browser.GetPageTitle(), eMagGeniusPage_Title);

        }

        /// <summary>
        /// Check hovering over the EMag Genius benefits, tool tip info is displayed.
        /// </summary>
        [Test]
        public void EMagGeniusToolTipDisplayTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(0));
            Console.WriteLine(PageWrapper.home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(0)));
        }

        /// <summary>
        /// Check hovering over the Easy Box benefits, tool tip info is displayed.
        /// </summary>
        [Test]
        public void EasyBoxToolTipDisplayTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(1));
            Assert.IsTrue(PageWrapper.home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(1)));
        }

        /// <summary>
        /// Check hovering over the Livrarea in 1h benefits, tool tip info is displayed.
        /// </summary>
        [Test]
        public void LivrareTazzToolTipDisplayTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(2));
            Assert.IsTrue(PageWrapper.home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(2)));
        }

        /// <summary>
        /// Check hovering over the Cardul EMag de la Raiffeisen benefits, tool tip info is displayed.
        /// </summary>
        [Test]
        public void RaiffeisenCardToolTipDisplayTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(3));
            Assert.IsTrue(PageWrapper.home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(3)));
        }

        /// <summary>
        /// Check hovering over the Daruiesteun voucher EMag benefits, tool tip info is displayed.
        /// </summary>
        [Test]
        public void DaruiesteVoucherToolTipDisplayTest()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(4));
            Assert.IsTrue(PageWrapper.home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(4)));
        }

        /// <summary>
        /// Assert the test switces to an IFrame, idenfies an element within the IFrame, clicks on it 
        /// & you are redirected to the correct page.
        /// NOTE!!!: the order of the iframes changes constantly, most probably you'll get redirected to a dofferent page, and the test will fail.
        /// Just change the expected page title with the one returned by the test output.
        /// </summary>
        [Test]
        public void TestOfertaZileiCarouselLink()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            Browser.Refresh();
            PageWrapper.home.CarouselDotsClick(1);
            PageWrapper.home.SwitchToIFrame();
            PageWrapper.home.ClickOnIframeLink();
            Assert.IsTrue(Browser.PageTitleContains(OfertaZileiPageTitle));

        }

    }
}
