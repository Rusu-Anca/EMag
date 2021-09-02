using EMagTest.Pages;
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

       

    }
}
