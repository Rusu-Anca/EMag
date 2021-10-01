using EMagTest.TestDataAccess;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest.Pages
{
    public class LoginPage : PageBase
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public By email_locaor => By.Id("user_login_email");

        public By continueButton_locator => By.Id("user_login_continue");
        public By password_locator => By.Id("user_login_password");

        public By trimiteCodButton_locator => By.ClassName("btn-primary");

        public By ValidareCodField_locator => By.Id("validate_mfa_code");

        public By validareCodContinueButton_locator => By.Id("validate_mfa_continue");

        public By googleLink_locator => By.ClassName("google");

        public By gmailEmail_locator => By.CssSelector("input[type='email']");

        public By gmailNextButton_locator => By.CssSelector(".qhFLie .VfPpkd-vQzf8d");
        public By gmailPassword_locator => By.CssSelector("input[type='password']");

        


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

        public void NavigateToGogle() => driver.FindElement(googleLink_locator).Click();

        public void InputGmailEmail(string gmail) => driver.FindElement(gmailEmail_locator).EnterText(gmail);

        public void ClickNextGmailButton() => driver.FindElement(gmailNextButton_locator).Click();

        public void InputGmailPassword(string gmailPassword) => driver.FindElement(gmailPassword_locator).EnterText(gmailPassword);

        public void InputEmail(string email) => driver.FindElement(email_locaor).EnterText(email);

        public void ClickContinue() => driver.FindElement(continueButton_locator).Click();
        public void TrimiteCodDeValidare() => driver.FindElement(trimiteCodButton_locator).Click();

        public void InputPassword(string password) => driver.FindElement(password_locator).EnterText(password);

        public void LogIn(string URL, string email, string password)
        {
            GoToURL(URL);
            driver.FindElement(email_locaor).EnterText(email);
            driver.FindElement(continueButton_locator).Click();
            driver.FindElement(password_locator, 10, displayed: true).EnterText(password);
            driver.FindElement(continueButton_locator).Click();
            driver.FindElement(trimiteCodButton_locator, 10, displayed: true).Click();

        }

        public void LogInWithGmail(string URL, string gmail, string gmailPassword)
        {
            GoToURL(URL);
            NavigateToGogle();
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
    }
}


