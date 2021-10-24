using EMagTest.Pages;
using EMagTest.TestSuite.Base;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EMagTest.TestSuite
{
    class FavoritesPageTest : TestBase
    {
        public List<string> PageStaticFilterHeaders = new List<string>() { "Tip:", "Compatibilitate maxima laptop:", "Brand:" };
        public List<string> BrandFilterOptions = new List<string>() { "Lenovo", "HP", "ASUS", "Apple" };
        public const string Product2Title = "Geanta Laptop Targus Geolite Essential 17.3 \"";
        public const string Department = "Laptop, Tablete & Telefoane";
        public const string ProductCategory = "Laptopuri si accesorii";
        public const string ProductLaptop = "Laptop Lenovo IdeaPad 3 14ADA05 cu procesor AMD Ryzen 5 3500U, 14\"";
        public const string ProductAspirator = "Aspirator Vertical Profesional Victronic, Putere 600 W, Filtru HEPA";


        /// <summary>
        /// Navigate to Laptop Product page, add a product to Favorites list & check it is displayed on the Favorites page.
        /// </summary>
        [Test]
        public void AddProductToFavoritesAndCheckItIsDisplayed()
        {

            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            PageWrapper.home.NavigateHomeAndCloseOfertaZilei();
            Browser.GoTo(Config.GentiLaptopPageURL);
            PageWrapper.topFilters.ClickOnFilterAndSelectOption(PageStaticFilterHeaders[2], BrandFilterOptions[2]);
            Thread.Sleep(2000);
            PageWrapper.product.AddProductToFavoritesList(Product2Title);
            bool isDisplayed = PageWrapper.userMenuBar.NavigateToFavorites().ProductIsDisplayedInFavoritesPage(Product2Title);
            Assert.IsTrue(isDisplayed);

        }

        /// <summary>
        /// 1.Navigate to Laptop Product page
        /// 2.Add a product to Favorites list
        /// 3.Navigate to Favorites page
        /// 4.Add the product to Cart
        /// 5.Navigate to Cart page & check it is displayed.
        /// </summary>
        [Test]
        public void AddFavoritePtoductToCart()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            PageWrapper.product.NavigateToLaptopCategoryPage(Department, ProductCategory);
            PageWrapper.topFilters.ClickOnFilterAndSelectOption(PageStaticFilterHeaders[2], BrandFilterOptions[0]);
            Thread.Sleep(1000);
            PageWrapper.product.AddProductToFavoritesList(ProductLaptop);
            PageWrapper.userMenuBar.NavigateToFavorites();
            // Thread.Sleep(500);
            PageWrapper.favoritesPage.AddProductToCart(ProductLaptop);
            // Thread.Sleep(500);
            PageWrapper.userMenuBar.NavigateToCARTPage();
            Thread.Sleep(500);
            Console.WriteLine(PageWrapper.cosulMeu.ProductDisplayed(ProductLaptop));


        }

        [Test]
        public void RemoveProductFromFavoritesPage()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            PageWrapper.product.NavigateToLaptopCategoryPage(Department, ProductCategory);
            PageWrapper.userMenuBar.NavigateToFavorites();
            PageWrapper.favoritesPage.RemoveProductFromFavorites(ProductAspirator);
            Assert.IsFalse(PageWrapper.favoritesPage.ProductIsDisplayedInFavoritesPage(ProductAspirator))
        }


    }
}
