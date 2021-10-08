using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite
{
    class ContulMeuTest
    {
        public const string Nota = "7";
        public const string PunctRidicareLink = "punct de ridicare";
        public const string PunctRidicareJudet = "Iaşi";
        public const string PunctRidicareLocalitate = "Iaşi";
        public string[] PunctRidicareName = { "easybox MOL Nicolina", "easybox Alisan Dancu" };

        static string[] panelsHeaderList =
            {
            "Datele contului",
            "eMAG Genius",
            "Evaluează experiența cu eMAG",
            "Punct de ridicare favorit" ,
            "Adresele mele",
            "Date facturare",
            "Card eMAG Raiffeisen",
            "Cardurile mele",
            "Aplicatia eMAG",
            "Cercetari de piata"
        };


        [SetUp]
        public void Setup()
        {
            Browser.Init(BrowserName.Chrome);
            Browser.GoTo(Config.LogInURL);
            Browser.WindowMaximize();
            PageWrapper.Init();
        }

        [TearDown]
        public void Close()
        {
            Browser.Close();
        }


        /// <summary>
        /// Check that the header on each panel is correctly displayed. 
        /// </summary>
        /// <param name="panelHeader"></param>
        [Test]
        [TestCaseSource("panelsHeaderList")]
        public void CheckTheHeaderOnThePanelIsCorrectlyDisplayed(string panelHeader)
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(1000);
            Assert.IsTrue(PageWrapper.contulMeuPage.MyAccountPanelsHeaderIsDisplayed(panelHeader));
        }

        /// <summary>
        /// Leave a feedback for EMag services.
        /// NOTE!!: This can be used only once.So a new user needs to be created to be able to test it.
        /// </summary>
        [Test]
        public void EvaluateEmagService()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(1000);
            PageWrapper.contulMeuPage.SelectNota(Nota);
            PageWrapper.contulMeuPage.InputFeedbackMessage("Could have been better");

        }

        /*
         * I want to create test case that click on the link displayed on each panel, and assert that I'm directed to the correct page
         * bt I need to create a generic method for all pages, so I can write only 1 method for all, instead of wringing a method
         * for each link.
         * 
         * Don't know how too create it!!!!
         * */

        [Test]
        public void SelectPunctDeRidicare()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(500);
            PageWrapper.contulMeuPage.ClickOnPanelLink(PunctRidicareLink);
            Thread.Sleep(2000);
            PageWrapper.contulMeuPage.ClickOnInapoiLaListaButton();
            PageWrapper.contulMeuPage.SelectPunctRidicareFavorit(PunctRidicareJudet, PunctRidicareLocalitate, PunctRidicareName[0]);


        }

    }

}

