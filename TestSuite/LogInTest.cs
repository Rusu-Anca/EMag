using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite
{
    class LogInTest
    {
        public const string AccountNameWelcome = "Salut, Rusu Ancuta Elena";

       
        /// <summary>
        /// Can't configure login tests due to Captcha!!!!
        /// </summary>
        [Test]
        public void LogInSuccessTest()
        {
            PageWrapper.login.LogIn(Config.LogInURL, Config.Credentials.Valid.Email, Config.Credentials.Valid.Password);
        }

        /// <summary>
        /// Can't login using GMail due blockers for using browsers controlled by automation tools.
        /// </summary>
        [Test]
        public void LogInWithGoogleAccount()
        {
            Browser.GoTo(Config.LogInURL);
            PageWrapper.login.LogInWithGmail(Config.LogInURL, Config.Credentials.ValidGmail.Email, Config.Credentials.ValidGmail.Password);
        }

        /// <summary>
        /// Login using Facebook credentials, and check that the correct account name is displayed.
        /// </summary>
        [Test]
        public void LoginWithFacebook()
        {
            Browser.GoTo(Config.LogInURL);
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(1000);
            Assert.IsTrue(PageWrapper.userMenuBar.CheckAccountName(AccountNameWelcome));

        }
    }
}
