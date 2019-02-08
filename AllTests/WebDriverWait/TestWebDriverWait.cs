using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.AllTests
{
    [TestClass]
    public class TestWebDriverWait
    {
        [TestMethod]
        public void TestWait()
        {
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());

            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        }

        [TestMethod]
        public void TestDynamicWait()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(waitForSearchBox());
            Console.WriteLine(wait.Until(waitForTitle()));
            wait.Until(waitForElement()).SendKeys("python");
            GenericHelper.GetElement(By.XPath("//button[@aria-label='Search' and @data-purpose='home-search-button']")).Click();
            wait.Until(waitForLastElement()).Click();
            Console.WriteLine("Title : {0}", wait.Until(waitForTitle()));

        }

        private Func<IWebDriver, bool> waitForSearchBox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Search Box");
                return x.FindElements(By.Id("search-field-home")).Count == 1;
            });
        }

        private Func<IWebDriver, string> waitForTitle()
        {
            return ((x) =>
            {
                if (x.Title.Contains("Online"))
                {
                    return x.Title;
                }
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitForElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Search Box");
                if(x.FindElements(By.Id("search-field-home")).Count == 1)
                {
                    return x.FindElement(By.Id("search-field-home"));
                }
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitForLastElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for the last item in list");
                if (x.FindElements(By.XPath("//div[text()='Python for Beginners: Learn Python Programming (Python 3)']")).Count == 1)
                {
                    return x.FindElement(By.XPath("//div[text()='Python for Beginners: Learn Python Programming (Python 3)']"));
                }
                return null;
            });
        }
        
        private Func<IWebDriver, string> waitForTitle2()
        {
            return ((x) =>
             {
                 Console.WriteLine("Waiting for Title");
                 if (x.FindElement(By.XPath("//h1[contains(@class,'clp-lead__title')]")).Text.Contains("Python for Beginners: Learn Python Programming (Python 3)"))
                 {
                     return x.FindElement(By.XPath("//h1[contains(@class,'clp-lead__title')]")).Text;
                 }
                 return null;
             });
        }

        [TestMethod]
        public void TestExpexctedCondition()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            wait.Until(ExpectedConditions.ElementExists(By.Id("search_query_top"))).SendKeys("T-Shirt");

            ButtonHelper.ClickButton(By.Name("submit_search"));

            TextBoxHelper.TypeInTextBox(By.Id("search_query_top"), "T-Shirts");
            LinkHelper.ClickLink(By.Name("submit_search"));

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@title='Faded Short Sleeve T-shirts']"))).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='exclusive added']"))).Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='exclusive added']")));
        }
    }
}
