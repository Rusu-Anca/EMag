using EMagTest.Pages;
using EMagTest.Pages.CategoryProductsPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace EMagTest.TestSuite
{
    class CategoryProductsPageTest
    {
        IWebDriver driver;
        public const string Department = "Laptop, Tablete & Telefoane";
        public const string ProductCategory = "Laptopuri si accesorii";
        public const string ProductSubCategory = "Laptopuri";
        public const string LaptopPageTitle = "Laptopuri - eMAG.ro";
        public const string EMagGeniusFilter_ToateProdusele = "Toate produsele ";
        public const string EMagGeniusFilter_Header = "eMAG Genius:";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../" + @"Resources\ChromeDriver"));
            driver.Navigate().GoToUrl(Config.GentiLaptopPageURL);
            driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }

        /// <summary>
        /// Navigate to a Products Category page, using the Main Menu links: Produse> Laptop, Tablete & Telefoane> Laptopuri si Accesorii> Laptopuri
        /// and Assert the Corrct page is displayed.
        /// </summary>
        [Test]
        public void NavigateToProductsCategoryPageFromMenu()
        {
            RibbonMenu rbMenu = new RibbonMenu(driver);
            rbMenu.LoadComplete();
            rbMenu.HoverOnMenuClickSubmenuItem(Department);
            SideMenu side_menu = new SideMenu(driver);
            side_menu.ClickOnProductCategorySideMenu(ProductCategory);
            Thread.Sleep(1000);
            side_menu.ClickOnLaptopCategory();
            Assert.AreEqual(side_menu.GetPageTitle(), LaptopPageTitle);

        }

        /// <summary>
        /// Tick an option from the Emag Genius Filter section and Assert it is displayed on the page correctly.
        /// </summary>
        [Test]
        public void SelectEMagFilterOption()
        {
            HomePage home = new HomePage(driver);
            home.DismissOfertaZileAndAcceptCookies();
            SideFilter filter = new SideFilter(driver);
            filter.SelectEmagGeniusFilter(EMagGeniusFilter_ToateProdusele);
            CategoryProductsPage categPage = new CategoryProductsPage(driver);
            Thread.Sleep(1000);
            Assert.IsTrue(categPage.CheckActiveFilterHeader(EMagGeniusFilter_ToateProdusele));

        }

    }
}
