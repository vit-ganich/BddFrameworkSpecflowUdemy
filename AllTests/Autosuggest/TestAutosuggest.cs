using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.AllTests.Autosuggest
{
    [TestClass]
    public class TestAutosuggest
    {
        [TestMethod]
        public void TestAutoSug()
        {
            NavigationHelper.NavigateToUrl("https://demos.telerik.com/kendo-ui/autocomplete/index");

            // Step #1 - supply an initial string
            IWebElement element = ObjectRepository.Driver.FindElement(By.Id("countries"));
            element.SendKeys("a");

            // Step #2 - wait for an AutoSuggest List
            var wait = GenericHelper.GetWebDriverWait(TimeSpan.FromSeconds(40));

            IList<IWebElement> elements = wait.Until(GetAllElements(By.XPath("//ul[@id='countries_listbox']/child::li")));

            foreach (var el in elements)
            {
                Console.WriteLine(el.Text);
                if (el.Text.Equals("Austria"))
                {
                    el.Click();
                }
            }

            Thread.Sleep(5000);
        }

        private Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return x => x.FindElements(locator);
        }
    }
}
