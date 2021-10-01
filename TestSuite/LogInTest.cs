using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite
{
    class LogInTest
    {

        [SetUp]
        public void Setup()
        {
            Browser.Init(BrowserName.Chrome);
            Browser.Loadpage(Config.BaseURL);
            PageWrapper.Init();
        }

        [TearDown]
        public void Close()
        {
            Browser.Close();
        }

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

            PageWrapper.login.GoToURL(Config.LogInURL);
            PageWrapper.login.LogInWithGmail(Config.LogInURL, Config.Credentials.ValidGmail.Email, Config.Credentials.ValidGmail.Password);


        }

    }
}
