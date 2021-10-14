using EMagTest.Pages;
using EMagTest.TestSuite.Base;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite
{
    class ContulMeuTest: TestBase
    {
        public const string Nota = "7";
        public const string PunctRidicareLink = "punct de ridicare";
        public const string PunctRidicareJudet = "Iaşi";
        public const string PunctRidicareLocalitate = "Iaşi";
        public string[] PunctRidicareName = { "easybox MOL Nicolina", "easybox Alisan Dancu" };
        public string[] AvatarPhotos = { "pisi1", "pisi2" };

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

        public override void Setup()
        {
            base.Setup();
            Browser.GoTo(Config.LogInURL);
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

        /// <summary>
        /// Navigate to the 'Alege punct ridicare favorit' modal, and select the favorite pick up point.
        /// ***NOTE!!!: please change the index of the PunctRidicareName before running this test, otherwise it will fail, as the
        /// last selected location is the current pick up location.
        /// </summary>
        [Test]
        public void SelectPunctDeRidicare()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(500);
            PageWrapper.contulMeuPage.ClickOnPanelLink(PunctRidicareLink);
            Thread.Sleep(2000);
            PageWrapper.contulMeuPage.ClickOnInapoiLaListaButton();
            PageWrapper.contulMeuPage.SelectPunctRidicareFavorit(PunctRidicareJudet, PunctRidicareLocalitate, PunctRidicareName[1]);
            Thread.Sleep(500);
            Assert.IsTrue(PageWrapper.contulMeuPage.CheckPunctRidicareFavoritPanelDetails(PunctRidicareName[1]));

        }

        [Test]
        public void CheckYouCanUploadAvatar()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(500);
            PageWrapper.contulMeuPage.UploadAvatar(AvatarPhotos[0]);
            Thread.Sleep(5000);

        }

        /// <summary>
        /// Delete the existing avatar and check it is not displayed anymore on the page.
        /// </summary>
        [Test]
        public void CheckYouCanDeleteTheAvatar()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            PageWrapper.contulMeuPage.DeleteAvatar();
            Browser.Refresh();
            Thread.Sleep(500);
            Assert.IsFalse(PageWrapper.contulMeuPage.CheckAvatarIsDisplayed());
        }

    }

}

