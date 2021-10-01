using EMagTest.Pages.CategoryProductsPage;
using EMagTest.WebDriverFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public static class PageWrapper
    {
        [ThreadStatic]
        public static HomePage home;
        public static LoginPage login;
        public static RibbonMenu ribbonMenu;
        public static SideMenu sideMenu;
        public static UserMenuBar userMenuBar;
        public static Product product;
        public static SideFilter sideFilter;
        public static TopFilters topFilters;
        public static EMagGeniusPage eMagGenius;

        public static void Init()
        {
            home = new HomePage(Browser.Current);
            login = new LoginPage(Browser.Current);
            ribbonMenu = new RibbonMenu(Browser.Current);
            sideMenu = new SideMenu(Browser.Current);
            userMenuBar = new UserMenuBar(Browser.Current);
            product = new Product(Browser.Current);
            sideFilter = new SideFilter(Browser.Current);
            topFilters = new TopFilters(Browser.Current);
            eMagGenius = new EMagGeniusPage(Browser.Current);

        }

    }
}
