using EMagTest.HelperMethods;

using EMagTest.Pages.CategoryProductsPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using EMagTest.WebDriverFactory;
using static EMagTest.WebDriverFactory.Browser;
using EMagTest.Pages;

namespace EMagTest.TestSuite
{
    public class GentiLaptopPageTest
    {

        public const string Department = "Laptop, Tablete & Telefoane";
        public const string ProductCategory = "Laptopuri si accesorii";
        public const string ProductSubCategory = "Laptopuri";
        public const string LaptopPageTitle = "Laptopuri - eMAG.ro";
        public const string EMagGeniusFilter_ToateProdusele = "Toate produsele";
        public const string EMagGeniusFilter_Header = "eMAG Genius";
        public List<string> DisponibilitateaOptions = new List<string>() { "In Stoc ", "Promotii ", "Resigilate ", "Noutati ", "eMAG Deschide Romania " };
        public List<string> BrandFilterOptions = new List<string>() { "Thule", "PORT DESIGNS", "Targus", "Samsonite", "Chesterfield", "Premium Quality", "Rivacase", "Suveran" };
        public List<string> PageStaticFilterHeaders = new List<string>() { "Tip:", "Compatibilitate maxima laptop:", "Brand:" };
        public List<string> PageActiveFilterHeaders = new List<string>() { "Disponibilitate", "Rating minim", "Disponibil prin easybox", "Functii", "Material", "Tip inchidere" };
        public List<string> NavigationButtons = new List<string>() { "Pagina anterioara", "1", "2", "60", "61", "Pagina urmatoare" };
        public const string DropdownDefaultValue = "Selecteaza...";
        public const string Product1Title = "Geanta laptop Thule Paramount 10.5\", Negru";
       // static string[] productName = { Product2Title, Product3Title };
        public const string Product2Title = "Husa Laptop Trust Primo, 15.6\", Negru";
        public const string Product3Title = "Rucsac Laptop A+ Reno, 15,6\", Black/Red";


        [SetUp]
        public void Setup()
        {
            Browser.Init(BrowserName.Chrome);
            Browser.Loadpage(Config.GentiLaptopPageURL);
            PageWrapper.Init();
        }

        [TearDown]
        public void Close()
        {
            Browser.Close();
        }

        /// <summary>
        /// Navigate to a Products Category page, using the Main Menu links: Produse> Laptop, Tablete & Telefoane> Laptopuri si Accesorii> Laptopuri
        /// and Assert the Corrct page is displayed.
        /// </summary>
        [Test]
        public void NavigateToProductsCategoryPageFromMenu()
        {
            //RibbonMenu rbMenu = new RibbonMenu(Browser.Current);
            PageWrapper.login.LoadComplete();
            PageWrapper.ribbonMenu.HoverOnMenuClickSubmenuItem(Department);
            PageWrapper.sideMenu.ClickOnProductCategorySideMenu(ProductCategory);
            Thread.Sleep(1000);
            PageWrapper.sideMenu.ClickOnLaptopCategory();
            Assert.AreEqual(PageWrapper.sideMenu.GetPageTitle(), LaptopPageTitle);

        }

        /// <summary>
        /// Collapse a filter and check if the options are no longer visible/displayed.
        /// </summary>
        [Test]
        public void CheckCollapsingFilterWorks()
        {
            PageWrapper.sideFilter.ExpandCollapseFilter(EMagGeniusFilter_Header);
            Thread.Sleep(500);
            Assert.IsFalse(PageWrapper.sideFilter.FilterOptionsDisplayed(EMagGeniusFilter_ToateProdusele));

        }

        /// <summary>
        /// Tick an option from the Emag Genius Filter section and Assert it is displayed on the page correctly.
        /// </summary>
        [Test]
        public void SelectEMagFilterOption()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.sideFilter.SelectEmagGeniusFilter(EMagGeniusFilter_ToateProdusele);
            TopFilters topFilters = new TopFilters(Browser.Current);
            Thread.Sleep(1000);
            Assert.IsTrue(topFilters.CheckActiveFilterDisplay(EMagGeniusFilter_ToateProdusele, 0));
        }

        /// <summary>
        /// Tick an option from the Disponibilitate Filter section and Assert it is displayed on the page correctly.
        /// </summary>
        [Test]
        public void SelectDisponibilitateaFilterOption()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.sideFilter.SelectDisponibilitateFilter(DisponibilitateaOptions[1]);
            Thread.Sleep(1000);
            TopFilters topFilters = new TopFilters(Browser.Current);
            Assert.IsTrue(topFilters.CheckActiveFilterDisplay(DisponibilitateaOptions[1], 0));
        }

        /// <summary>
        /// Check you can scroll to a filter option, select it and the filter is correctly displayed within the active filters 
        /// section of the Category Products page.
        /// </summary>
        [Test]
        public void CheckSelectedFilterOptionIsDisplayed()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.sideFilter.ScrollAndSelectBrandFilter(BrandFilterOptions[0]);
            Thread.Sleep(2000);
            Assert.IsTrue(PageWrapper.topFilters.CheckStaticFilterDisplay(BrandFilterOptions[0]));
        }


        /// <summary>
        /// Select a Brand filter option from the side filters and check that the static filter displays the selected filter.
        /// </summary>
        [Test]
        public void CheckSelectedStaticFilterIsDisplayed()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            PageWrapper.sideFilter.ScrollAndSelectBrandFilter(BrandFilterOptions[0]);
            Thread.Sleep(1000);
            Assert.IsTrue(PageWrapper.topFilters.CheckStaticFilterDisplay(BrandFilterOptions[0]));

        }

        /// <summary>
        /// Select multiple filter options from the same filter, and check the dowpdown name contains the selected option.
        /// </summary>
        [Test]
        public void CheckSelectedStaticFilterOptionsAreDisplayed()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            //Thread.Sleep(2000);
            PageWrapper.topFilters.ClickDropdownFilterOption(PageStaticFilterHeaders[2]);
            PageWrapper.topFilters.SelectFilterOption(BrandFilterOptions[0]);
            PageWrapper.topFilters.ClickDropdownFilterOption(PageStaticFilterHeaders[2]);
            string selectedFilters = PageWrapper.topFilters.SelectFilterOption(BrandFilterOptions[4]);
            Assert.IsTrue(selectedFilters.Contains(BrandFilterOptions[4]));

        }

        /// <summary>
        /// Add filter option from the right side filters section, remove it from the 
        /// top active filters section, and check the correct dropdown default value is displayed.
        /// </summary>
        [Test]
        public void CheckdropdownDefaultValueWhenRemoveFilterOptions()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            SideFilter filter = new SideFilter(Browser.Current);
            filter.SelectDisponibilitateFilter(DisponibilitateaOptions[1]);
            TopFilters topFilters = new TopFilters(Browser.Current);
            topFilters.ClickOnRemoveFilterOptionButton(PageActiveFilterHeaders[0]);
            string dropdownValue = topFilters.ClickDropdownFilterOption(PageStaticFilterHeaders[2]);
            Assert.AreEqual(DropdownDefaultValue, dropdownValue);

        }

        /// <summary>
        /// Select a filter option from the Brand static filter and check if the products displayd on the page contains the selected brand.
        /// </summary>
        [Test]
        public void SelectStaticFilterAndCheckCorrectProductsAreDisplayed()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            TopFilters topFilters = new TopFilters(Browser.Current);
            topFilters.ClickDropdownFilterOption(PageStaticFilterHeaders[2]);
            topFilters.SelectFilterOption(BrandFilterOptions[0]);
            Console.WriteLine(PageWrapper.product.CheckProductsTitleContains(BrandFilterOptions[0]));
            Thread.Sleep(2500);
            Assert.IsTrue(PageWrapper.product.CheckProductsTitleContains(BrandFilterOptions[0]));
        }

        /// <summary>
        /// Select a filter option, identify the desired product, add it to Favorites and check success confirmation message is displayed.
        /// </summary>
        [Test]
        public void AddProdcutToFavoriteListANDCheckConfirmationMessage()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            TopFilters topFilters = new TopFilters(Browser.Current);
            topFilters.ClickDropdownFilterOption(PageStaticFilterHeaders[2]);
            topFilters.SelectFilterOption(BrandFilterOptions[0]);
            Thread.Sleep(2000);
            PageWrapper.product.AddProductToFavoritesList(Product1Title);
            Assert.IsTrue(PageWrapper.product.FavoriteSuccessMessage());

        }

        /// <summary>
        /// On the GentiLaptop page search for a specific product, if not found then navigate to the next page
        /// until found, then click on Add To cart buton and check the Confirmation modal is displayed.
        /// </summary>
        /// 
        /*
         *This doesn't work if my product is displayed on the next pages as I get Stale element error after I navigate to the next page.
         *It works ony when the searched product is on the 1st page.
         *It works on debugging though.
         *It has to do with waiting the element to be displayed.
          **/
        [Test]
        [TestCase(Product2Title)]
        [TestCase(Product3Title)]
        public void AddProductToCart(string ProductName)
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            Assert.IsTrue(PageWrapper.product.AddProductToMyCart(ProductName));

        }

        /// <summary>
        /// Check that when the user is on the 1st page the Pagina Anterioara button is disabled.
        /// </summary>
        [Test]
        public void AssertPaginaAnterioaraIsDisabledWhenOnFirstPage()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            Console.WriteLine(PageWrapper.product.CheckNavigationButtonIsDisabled(NavigationButtons[0]));
            Assert.IsTrue(PageWrapper.product.CheckNavigationButtonIsDisabled(NavigationButtons[0]));
        }

        /// <summary>
        /// Check that when the user navigates on the last page the PaginaAnterioara button is enabled and PaginaUrmatoare is disabled.
        /// </summary>
        [Test]
        public void AssertPaginaAnterioaraIsEnabledAndPaginaUrmatoareIsDisabledWhenOnLastPage()
        {
            PageWrapper.home.DismissOfertaZileAndAcceptCookies();
            Thread.Sleep(500);
            PageWrapper.product.ClickOnNavigationButton(NavigationButtons[4]);
            Thread.Sleep(500);
            Assert.IsFalse(PageWrapper.product.CheckNavigationButtonIsDisabled(NavigationButtons[0]));
            Assert.IsTrue(PageWrapper.product.CheckNavigationButtonIsDisabled(NavigationButtons[5]));
        }

    }
}
