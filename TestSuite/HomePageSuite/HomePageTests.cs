using EMagTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EMagTest.TestSuite
{
    class HomePageTests
    {
        IWebDriver driver;
        public const string HomePage_Title = "eMAG.ro - Libertate în fiecare zi";
        public const string eMagGeniusPage_Title = "eMAG genius: serviciul tău premium de cumpărături - eMAG.ro";
        Dictionary<string, string> benefits_collection = new Dictionary<string, string> {
            { "eMAG Genius", "Bucură-te de cumpărături cu beneficii premium!" },
            {"easybox by eMAG","Comanzi când vrei, ridici când poți! În plus, poți să returnezi la easybox produsele care nu ți se potrivesc!" },
            {"Livrare în 1h","Bucură-te de livrări în super viteză cu Tazz by eMAG! În doar o oră, primești ce îți dorești din showroom, magazine sau restaurante!" },
            {"Cardul eMAG de la Raiffeisen Bank","Aplica acum! Ai până la 10% înapoi în puncte și până la 24 rate fara dobândă." },
            {"Dăruiește un voucher eMAG ","Fă-le o surpriză celor dragi și oferă-le un voucher cadou cu care să își cumpere exact ce își doresc!" }
        };
        public const string OfertaZileiPageTitle = "Oferta zilei bauturi 24 august: Whiskey, vodka & cognac"; // "Fier de calcat portabil Rowenta Tweeny Nano DV9000D1, Calcare verticala si orizontala, 950W, Rezervor detasabil 50ml, Autonomie 10min, Perie pentru tesaturi, Alb - eMAG.ro";
        public const string ProductCategory = "Laptopuri si accesorii";
        public const string ProductSubCategory = "Laptopuri";

        public const string SubMenu = "Laptop, Tablete & Telefoane";
        public const string LaptopPageTitle = "Laptopuri - eMAG.ro";



        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../" + @"Resources\ChromeDriver"));
            driver.Navigate().GoToUrl(Config.BaseURL);
            driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void AcceptCookiesTest()
        {
            HomePage home = new HomePage(driver);
            Thread.Sleep(500);
            home.CloseOfertaZilei();
            home.AcceptCookies();

        }

        [Test]
        public void DismissLoginButtonTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
        }

        [Test]
        public void EMagGeniusBenefitRedirectTest()
        {
            HomePage home = new HomePage(driver);
            home.ClickOnBenefitsElement(benefits_collection.Keys.ElementAt(0));
            EMagGeniusPage genius = new EMagGeniusPage(driver);
            Assert.AreEqual(genius.GetPageTitle(), eMagGeniusPage_Title);

        }

        /// <summary>
        /// Dismisse Oferta zilei, and accept Cookies, then hover over the 
        /// eMag Genius benefit, and clicks on the Vezi mai multe detalii link and asserts the page title is correct.
        /// </summary>
        [Test]
        public void EMagGeniusBenefitToolTipLinkTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(0));
            home.ClickOnToolTipLink();
            EMagGeniusPage genius = new EMagGeniusPage(driver);
            Assert.AreEqual(genius.GetPageTitle(), eMagGeniusPage_Title);

        }



        [Test]
        public void EMagGeniusToolTipDisplayTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(0));
            Console.WriteLine(home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(0)));
        }


        [Test]
        public void EasyBoxToolTipDisplayTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(1));
            Assert.IsTrue(home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(1)));
        }

        [Test]
        public void LivrareTazzToolTipDisplayTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(2));
            Assert.IsTrue(home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(2)));
        }

        [Test]
        public void RaiffeisenCardToolTipDisplayTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(3));
            Assert.IsTrue(home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(3)));
        }

        //this test fails and I can't determine the reason- after hover the tooltip pane is no longer displayed
        [Test]
        public void DaruiesteVoucherToolTipDisplayTest()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.HoverOverBenefitsElement(benefits_collection.Keys.ElementAt(4));
            Assert.IsTrue(home.CheckToolTipIsDisplayed(benefits_collection.Values.ElementAt(4)));
        }

        [Test]
        public void GetFrameIDs()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.CountIFrames();
        }

        [Test]
        public void TestOfertaZileiCarouselLink()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            home.Refresh();
            home.CarouselDotsClick(1);
            home.SwitchToIFrame();
            home.ClickOnIframeLink();
            Assert.AreEqual(home.GetPageTitle(), OfertaZileiPageTitle);
        }

        [Test]
        public void NavigateLaptopsPageFromMenu()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            RibbonMenu menu = new RibbonMenu(driver);
            menu.HoverOnMenuClickSubmenuItem(SubMenu);
            SideMenu side_menu = new SideMenu(driver);
            side_menu.ClickOnProductCategorySideMenu(ProductCategory);
            Thread.Sleep(1000);
            side_menu.ClickOnLaptopCategory();
            Assert.AreEqual(side_menu.GetPageTitle(), LaptopPageTitle);

        }
    }
}
