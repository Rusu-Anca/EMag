using EMagTest.HelperMethods;
using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite.ContulMeuSuite
{
    class DatePersonaleTest
    {
        public const string DateleTaleLinkName = "administreaza datele tale";
        public string[] gender = { "Male", "Female" };
        public string[] educatie = { "Selectați ...", "Colegiu/Studii postliceala", "Doctorat", "Facultate (in curs)", "Facultate (terminata)", "Liceu", "MBA", "Studii postuniversitare" };
        public List<string> dateleMeleLabelList = new List<string> { "Forma de adresare:", "Nume Prenume:", "Nickname:", "Telefon Fix:", "Data nașterii:", "Nivel educatie:" };
        Random _random = new Random();

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
            string year = Randomise.RandomFromInterval(1920, 2011);
            string month = Randomise.RandomMonth();
            string day = Randomise.RandomDay(year, month);
            string phoneNo = "07" + Randomise.RandomNumberOfLength(8);
            string nickName = "ANK_" + Randomise.RandomStringOfLength(6);
            string nivelEducatie = educatie[_random.Next(0, educatie.Length)];
            PageWrapper.login.LoginWithFacebook(Config.Credentials.ValidFacebook.Email, Config.Credentials.ValidFacebook.Password, Config.Credentials.ValidFacebook.SocialEmailPassword);
            Thread.Sleep(500);
            PageWrapper.contulMeuPage.ClickOnPanelLink(DateleTaleLinkName);
            PageWrapper.datePersonalePage.FillInDateleMeleForm(nickName, phoneNo, year, month, day, nivelEducatie);
            Thread.Sleep(1000);
            Assert.IsTrue(PageWrapper.datePersonalePage.CheckDateleMeleDetails(nickName));
            Assert.IsTrue(PageWrapper.datePersonalePage.CheckDateleMeleDetails(phoneNo));
            Assert.IsTrue(PageWrapper.datePersonalePage.CheckDateleMeleDetails($"{day} {(Months)Randomise.SplitMonth(month)} {year}"));
            Assert.IsTrue(PageWrapper.datePersonalePage.CheckDateleMeleDetails(nivelEducatie));


        }
    }
}
