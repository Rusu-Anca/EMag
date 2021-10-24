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
        public List<string> BrandFilterOptions = new List<string>() { "Thule", "PORT DESIGNS", "Targus", "Samsonite", "Chesterfield", "Premium Quality", "Rivacase", "Suveran" };
        public const string Product2Title = "Geanta Laptop Targus Geolite Essential 17.3 \"";

        [Test]
        public void AddProductToFavoritesAndCheckItIsDisplayed()
        {

            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            PageWrapper.home.NavigateHome();
            PageWrapper.home.CloseOfertaZilei();
            Browser.GoTo(Config.GentiLaptopPageURL);
            PageWrapper.topFilters.ClickOnFilterAndSelectOption(PageStaticFilterHeaders[2], BrandFilterOptions[2]);
            Thread.Sleep(2000);
            PageWrapper.product.AddProductToFavoritesList(Product2Title);
            bool isDisplayed = PageWrapper.userMenuBar.NavigateToFavorites().ProductIsDisplayedInFavoritesPage(Product2Title);
            //Console.WriteLine(PageWrapper.favoritesPage.ProductIsDisplayedInFavoritesPage(Product2Title));
            Console.WriteLine(isDisplayed);

        }
    }
}
