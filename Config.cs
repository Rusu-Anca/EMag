using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest
{
    class Config
    {

        public static int ElementsWaitingTimeout = 5;
        public static string BaseURL = "https://www.emag.ro/";
        public static string LogInURL = "https://auth.emag.ro/user/login";
        public static string LogInCodeURL = "https://auth.emag.ro/user/validate-mfa";
        public static string GentiLaptopPageURL = "https://www.emag.ro/genti-laptop/c?ref=search_menu_category";

        public static class Credentials
        {
            public static class Valid
            {
                public static string Email = " i1.anca.rusu@yopmail.com";
                public static string Username = "Anca Rasa";
                public static string Password = "Punch56Bk!";
            }

            public static class ValidGmail
            {
                public static string Email = "i1.anca.e.david@gmail.com";
                public static string Password = "WakeMe8!UP!";
            }

            public static class Invalid
            {
                public static class Email
                {
                    public static string NoUser = "@example.com";
                    public static string NoAt = "exampleexample.com";
                    public static string NoDomain = "example@";
                    public static string NoExtension = "example@example";
                }

                public static class Username
                {
                    public static string FourCharacters = "abcd";
                    public static string ThirteenCharacters = "abcdabcdabcda";
                    public static string OnlyLetters = "abcdabcd";
                    public static string OnlyNumbers = "123456789";
                    public static string OnlySpecialSymbols = "$#@%)(*$%#%?><";
                    public static string NoSpecialSymbol = "asd1234";
                }

                public static class Password
                {
                    public static string FourCharacters = "abcd";
                    public static string ThirteenCharacters = "abcdabcdabcda";
                    public static string OnlyLetters = "abcdabcd";
                    public static string OnlyNumbers = "123456789";
                    public static string OnlySpecialSymbols = "$#@%)(*$%#%?><";
                    public static string NoSpecialSymbol = "asd1234";
                }
            }
        }

        public static class MenuElements
        {
            public static string Introduction = "Introduction";
            public static string Selectors = "Selectors";
            public static string SpecialElements = "Special Elements";
            public static string TestCases = "Test Cases";
            public static string TestScenarios = "Test Scenarios";
            public static string About = "About";
        }

        public static class TestMessages
        {

        }

        public static class AlertsTexts
        {
            public static string UsernameLengthOutOfRange = "User Id should not be empty / length be between 5 to 12";
            public static string PasswordLenghtOutOfRange = "Password should not be empty / length be between 5 to 12";
            public static string SuccessfulLogin = "Succesful login!";
        }
    }

}
