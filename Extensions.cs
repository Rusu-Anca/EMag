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

        public static void EnterText(this IWebElement element, string text)
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
            catch (Exception)
            {
                result = false;
                Console.WriteLine($"{elemName} is NOT displayed");
            }
            return result;
        }
        /// <summary>
        /// Find an element, waiting until a timeout is reached if necessary.
        /// </summary>
        /// <param name="context">The search context.</param>
        /// <param name="by">Method to find elements.</param>
        /// <param name="timeout">How many seconds to wait.</param>
        /// <param name="displayed">Require the element to be displayed?</param>
        /// <returns>The found element.</returns>
        public static IWebElement FindElement(this ISearchContext context, By by, uint timeOutInSeconds, bool displayed = false)
        {

            var wait = new DefaultWait<ISearchContext>(context);
            wait.Timeout = TimeSpan.FromSeconds(timeOutInSeconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until<IWebElement>(ctx =>
           {
               var elem = ctx.FindElement(by);
               if (displayed && !elem.Displayed)
                   return null;

               return elem;

           });

        }

        /// <summary>
        ///     Method that finds a list of elements based on the search parameters within a specified timeout.
        /// </summary>
        /// <param name="context">The context where this is searched. Required for extension methods</param>
        /// <param name="by">The search parameters that are used to identify the element</param>
        /// <param name="timeoutInSeconds">The time that the tool should wait before throwing an exception</param>
        /// <returns>A list of all the web elements that match the condition specified</returns>
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
