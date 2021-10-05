using EMagTest.TestDataAccess;
using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EMagTest.Pages
{
    public class LoginPage : PageBase
    {
/*
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
*/
        public By email_locaor => By.Id("user_login_email");

        public By continueButton_locator => By.Id("user_login_continue");
        public By password_locator => By.Id("user_login_password");

        public By socialEmailPassword_locator => By.Id("social_email_password");

        public By socialEmailContinueButton_locator => By.Id("social_email_continue");

        public By trimiteCodButton_locator => By.ClassName("btn-primary");

        public By ValidareCodField_locator => By.Id("validate_mfa_code");

        public By validareCodContinueButton_locator => By.Id("validate_mfa_continue");

        public By googleLink_locator => By.ClassName("google");

        public By gmailEmail_locator => By.CssSelector("input[type='email']");

        public By gmailNextButton_locator => By.CssSelector(".qhFLie .VfPpkd-vQzf8d");
        public By gmailPassword_locator => By.CssSelector("input[type='password']");

        public By facebook_locator => By.ClassName("facebook");

        public By facebookAcceptCookies_locator => By.CssSelector("button[data-testid='cookie-policy-dialog-accept-button']");
        public By facebookEmail_locator => By.Id("email");
        public By facebookPassword_locator => By.Id("pass");

        public By FacebookLoginButton_locator => By.Id("loginbutton");

        public By continueToEmagButton_locator => By.CssSelector("button[name='__CONFIRM__']");


        /* public void InputEmail(string testName)
         {
             var userData = ExcelDataAccess.GetTestData(testName);
             driver.FindElement(email_locaor).EnterText(userData.Email);
         }*/

        /* public void InputPassword(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            driver.FindElement(password_locator).EnterText(userData.Password);
        }*/

        public void NavigateToGoogle() => Browser.ClickWebElement(googleLink_locator);

        public void InputGmailEmail(string gmail) => Browser.FindElement(gmailEmail_locator).EnterText(gmail);

        public void ClickNextGmailButton() => Browser.ClickWebElement(gmailNextButton_locator);

        public void InputGmailPassword(string gmailPassword) => Browser.FindElement(gmailPassword_locator).EnterText(gmailPassword);

        public void InputEmail(string email) => Browser.FindElement(email_locaor).EnterText(email);

        public void ClickContinue() => Browser.ClickWebElement(continueButton_locator);
        public void TrimiteCodDeValidare() => Browser.ClickWebElement(trimiteCodButton_locator);

        public void InputPassword(string password) => Browser.FindElement(password_locator).EnterText(password);

        public void InputSocialEmalPassword(string password) => Browser.FindElement(socialEmailPassword_locator).EnterText(password);

        public void ClickSocialEmailContinueButton() => Browser.ClickWebElement(socialEmailContinueButton_locator);

        /// <summary>
        /// Login to Emag using credentials.
        /// </summary>
        /// <param name="URL">Login URL.</param>
        /// <param name="email">Emag email.</param>
        /// <param name="password">Emag password.</param>
        /// Can't use this flow as Capcha panel is displayed and can't get pass it.
        public void LogIn(string URL, string email, string password)
        {
            Browser.GoTo(URL);
            Browser.FindElement(email_locaor).EnterText(email);
            Browser.ClickWebElement(continueButton_locator);
            Browser.FindElement(password_locator).EnterText(password);
            Browser.ClickWebElement(continueButton_locator);
            Browser.ClickWebElement(trimiteCodButton_locator);

        }


        /// <summary>
        /// Login using Gmail credentials.
        /// </summary>
        /// <param name="URL">Login URL.</param>
        /// <param name="gmail">Gmail email address.</param>
        /// <param name="gmailPassword">Gmail password.</param>
        /// Can't use this flow as Capcha panel is displayed and can't get pass it.
        public void LogInWithGmail(string URL, string gmail, string gmailPassword)
        {
            Browser.GoTo(URL);
            NavigateToGoogle();
            InputGmailEmail(gmail);
            ClickNextGmailButton();
            InputGmailPassword(gmailPassword);
            ClickNextGmailButton();

        }

        /* tryig to get the test data from excel sheet
         * 
         * public void LogIn(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            driver.FindElement(email_locaor).EnterText(userData.Email);
            
        InputEmail(testName);
        ClickContinue();
        InputPassword(testName);
        ClickContinue();
        TrimiteCodDeValidare(); 
        
        }*/

        public void NavigateToFacebookLogin() => Browser.ClickWebElement(facebook_locator);

        public void FacebookAcceptCookies() => Browser.ClickWebElement(facebookAcceptCookies_locator);

        public void InputFacebookEmail(string email) => Browser.FindElement(facebookEmail_locator).EnterText(email);

        public void InputFacebookPassword(string password) => Browser.FindElement(facebookPassword_locator).EnterText(password);

        public void ClickOnFacebookLoginButton() => Browser.ClickWebElement(FacebookLoginButton_locator);
        public void ClickOnContinueButton() => Browser.ClickWebElement(continueToEmagButton_locator);

        /// <summary>
        /// Login to Emag using Facebook credentials.
        /// </summary>
        /// <param name="email">Facebook email.</param>
        /// <param name="password">Facebook password.</param>
        /// <param name="socialPassword">Emag password.</param>
        public void LoginWithFacebook(string email, string password, string socialPassword)
        {
            NavigateToFacebookLogin();
            FacebookAcceptCookies();
            InputFacebookEmail(email);
            InputFacebookPassword(password);
            ClickOnFacebookLoginButton();
            // InputSocialEmalPassword(socialPassword);
            // ClickSocialEmailContinueButton();
            // Browser.DismissAlert(socialPassword);
            // ClickOnContinueButton();
        }

    }


}


