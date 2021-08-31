using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMagTest
{
    public static class Extensions
    {

        public static void EnterText(this IWebElement element, string text )
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static bool IsDisplayed(this IWebElement element, string elemName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine($"{elemName} is displayed");
            }
            catch(Exception)
            {
                result = false;
                Console.WriteLine($"{elemName} is NOT displayed");
            }
            return result;
        }


        public static IWebElement FindElement(this ISearchContext context, By by, uint timeOutInSeconds)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new DefaultWait<ISearchContext>(context);
                wait.Timeout = TimeSpan.FromSeconds(timeOutInSeconds);
                return wait.Until<IWebElement>(ctx => ctx.FindElement(by));
            }

            return context.FindElement(by);

        }

        public static IReadOnlyCollection<IWebElement> FindElements(this ISearchContext context, By by, uint timeOutInSeconds)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new DefaultWait<ISearchContext>(context);
                wait.Timeout = TimeSpan.FromSeconds(timeOutInSeconds);
                return wait.Until<IReadOnlyCollection<IWebElement>>(ctx => ctx.FindElements(by));
            }

            return context.FindElements(by);

        }

        public static void ActionsMouseHover(this IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Perform();
            
        }
    }
}
