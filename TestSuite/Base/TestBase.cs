using EMagTest.Pages;
using EMagTest.WebDriverFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static EMagTest.WebDriverFactory.Browser;

namespace EMagTest.TestSuite.Base
{
    public abstract class TestBase
    {

        [SetUp]
        public virtual void Setup()
        {
            Browser.Init(BrowserName.Chrome);
            Browser.GoTo(Config.BaseURL);
            Browser.WindowMaximize();
            PageWrapper.Init();
        }

        [TearDown]
        public virtual void Close()
        {
            Browser.Close();
        }
    }
}
