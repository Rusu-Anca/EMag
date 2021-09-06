using EMagTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EMagTest.TestSuite
{
    class LogInTest
    {
        public IWebDriver driver;
        private const string Login_URL = "https://auth.emag.ro/user/login";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../" + @"Resources\ChromeDriver"));
            driver.Navigate().GoToUrl(Config.BaseURL);
            driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }

        /// <summary>
        /// Can't configure login tests due to Captcha!!!!
        /// </summary>
        [Test]
        public void LogInSuccessTest()
        {

            LoginPage login = new LoginPage(driver);
           // login.GoToURL(Login_URL);
            login.LogIn(Config.LogInURL, Config.Credentials.Valid.Email, Config.Credentials.Valid.Password);
        }

        /// <summary>
        /// Can't login using GMail due blockers for using browsers controlled by automation tools.
        /// </summary>
        [Test]
        public void LogInWithGoogleAccount()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToURL(Login_URL);
            //login.NavigateToGogle();
            login.LogInWithGmail(Config.LogInURL, Config.Credentials.ValidGmail.Email, Config.Credentials.ValidGmail.Password);


        }

    }
}
