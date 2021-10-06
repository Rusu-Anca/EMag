using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite.ContulMeuSuite
{
    class DatePersonaleTest
    {
        public const string DateleTaleLinkName = "administreaza datele tale";
        public string[] gender = { "Male", "Female" };

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
        public void FillInDateleMeleFormSubmitANDCheckOK()
        {
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            PageWrapper.contulMeuPage.ClickOnPanelLink(DateleTaleLinkName).SelectFormaDeAdresare(gender[1]);
        }
    }
}
