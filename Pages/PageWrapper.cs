using EMagTest.Pages.CategoryProductsPage;
using EMagTest.Pages.MyAccount;
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
        public static ContulMeuPage contulMeuPage;
        public static DatePersonalePage datePersonalePage;

        public static void Init()
        {
            home = new HomePage();
            login = new LoginPage();
            ribbonMenu = new RibbonMenu();
            sideMenu = new SideMenu();
            userMenuBar = new UserMenuBar();
            product = new Product();
            sideFilter = new SideFilter();
            topFilters = new TopFilters();
            eMagGenius = new EMagGeniusPage();
            contulMeuPage = new ContulMeuPage();
            datePersonalePage = new DatePersonalePage();
    }

}
}
