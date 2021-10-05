using EMagTest.HelperMethods;
using EMagTest.Pages;
using EMagTest.Pages.MyAccount;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace EMagTest
{
    public class PageBase
    {
        public readonly UserMenuBar userMenuBar;
        public readonly RibbonMenu ribbonMenu;
        public readonly SideMenu sideMenu;
        public readonly DatePersonalePage datePersonalePage;
        public readonly ContulMeuPage contulMeuPage;
        
        public PageBase() 
        {
            userMenuBar = new UserMenuBar();
            ribbonMenu = new RibbonMenu();
            sideMenu = new SideMenu();
            contulMeuPage = new ContulMeuPage();
            datePersonalePage = new DatePersonalePage();
        }

       

    }
}
