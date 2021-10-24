using EMagTest.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EMagTest.HelperMethods
{
    public static class WebElementsHelperMethods
    {
        /// <summary>
        /// Iterate through the list of displayed web elements and check if the searched element is present.
        /// </summary>
        /// <param name="elementCollection">The web element list.</param>
        /// <param name="elementName">The name/title of the web element.</param>
        /// <returns>True if the element is displayed, False otherwise.</returns>
        public static bool ElementInTheListIsDisplayed(IReadOnlyCollection<IWebElement> elementCollection, string elementName)
        {
            bool result = false;
            foreach (IWebElement element in elementCollection)
            {
                if (element.Text.Contains(elementName))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Traverses a collection of web elements and clicks on the element that matches the name of the element we are looking for.
        /// </summary>
        /// <param name="elementCollection">The  web element collection/list.</param>
        /// <param name="elementName">The name of the element we are looking for.</param>
        public static void ClickOnCollectionElementIfMatches(IReadOnlyCollection<IWebElement> elementCollection, string elementName)
        {
            foreach (IWebElement element in elementCollection)
            {
                if (element.Text.Contains(elementName))
                {
                    element.Click();
                    break;
                }
            }
        }

        public static void ClickOnCollectionElementIfAttributeMatches(IReadOnlyCollection<IWebElement> elementCollection, string attribute, string attributeName)
        {
            foreach (IWebElement element in elementCollection)
            {
                if (element.HasAttribute(attribute, attributeName))
                {
                    element.Click();
                    break;
                }
            }
        }

        public static void ScrollAndClickOnCollectionElementIfMatches(IReadOnlyCollection<IWebElement> webElementCollection, string elementName)
        {
            foreach (IWebElement element in webElementCollection)
            {
                if (element.Text.Contains(elementName))
                {
                    Browser.ScrollToElement(element);
                    element.Click();
                    break;
                }
            }
        }

        public static string GetElementDescriptionFromWebElementCollection(IReadOnlyCollection<IWebElement> webElementCollection, string expected)
        {
            string elementTitle = null;
            foreach (IWebElement title in webElementCollection)
            {
                if (title.Text.Contains(expected))
                {
                    elementTitle = title.Text;
                }

            }

            return elementTitle;
        }

        /// <summary>
        /// Identify parent element from the web element collection, then identify the child element and click on it.
        /// </summary>
        /// <param name="webElementCollection">The collection of parent elements.</param>
        /// <param name="elemtDescription">The parent description.</param>
        /// <param name="by">Child locator.</param>
        public static void ClickOnChildElement(IReadOnlyCollection<IWebElement> webElementCollection, string elemtDescription, By by)
        {
            foreach (var product in webElementCollection)
            {
                Console.WriteLine(product.Text);
                if (product.Text.Contains(elemtDescription))
                {
                    IWebElement childElem = product.FindElement(by);
                    childElem.Click();
                    break;
                }
            }

        }

      

    }
}
