using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By locator)
        {
            return ObjectRepository.Driver.FindElements(locator).Count == 1;
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
            {
                return ObjectRepository.Driver.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException(string.Format("Element Not Found: {0}", locator));
            }
        }

        public static IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            if (IsElementPresent(locator))
            {
                return ObjectRepository.Driver.FindElements(locator);
            }
            else
            {
                throw new NoSuchElementException(string.Format("Elements Not Found: {0}", locator));
            }
        }

        public static bool WaitForWebElement(By locator, int timeout=5)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeout));

            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            bool flag = wait.Until(WaitForWebElementFunc(locator));

            // Reset the ImplicitWait timeout to the App.config value
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());

            return flag;
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for element : {0}", locator);
                if (x.FindElements(locator).Count == 1)
                {
                    return true;
                }
                return false;
            });
        }

        public static IWebElement WaitForWebElementInPage(By locator, int timeout=5)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeout));

            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            IWebElement element = wait.Until(WaitForWebElementInPageFunc(locator));

            // Reset the ImplicitWait timeout to the App.config value
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());

            return element;
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for element : {0}", locator);
                if (x.FindElements(locator).Count == 1)
                {
                    return x.FindElement(locator);
                }
                return null;
            });
        }
    }
}
