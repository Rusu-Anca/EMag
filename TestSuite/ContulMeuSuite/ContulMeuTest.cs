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




    }

}

