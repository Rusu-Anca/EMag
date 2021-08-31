using EMagTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace EMagTest
{
    public class Tests
    {

        IWebDriver driver;
        public const string HomePage_Title = "eMAG.ro - Libertate în fiecare zi";

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

        [Test]
        public void Test1()
        {
            HomePage home = new HomePage(driver);
            Assert.IsTrue(home.AssertTitle(HomePage_Title));
        }

        [Test]
        public void Test2()
        {
            // driver.SwitchTo().Frame("google_ads_iframe_ / 296121929 / Slider_Home_1_0");
            // string link = driver.FindElement(By.XPath("html/body/div/a")).GetAttribute("href");
            IReadOnlyCollection<IWebElement> frames = driver.FindElements(By.CssSelector(".js-banner-carousel.ph-has-dots iframe"));
            Thread.Sleep(5000);
            System.Console.WriteLine(frames.Count);
            foreach(IWebElement fr in frames)
            {
                System.Console.WriteLine(fr.GetAttribute("id"));
            }
        }
    }
}