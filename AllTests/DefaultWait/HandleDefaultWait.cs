using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());
            LinkHelper.ClickLink(By.LinkText("Women"));
            LinkHelper.ClickLink(By.Id("uniform-selectProductSort"));

            // Before a custom methods creation
            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //IWebElement element = ObjectRepository.Driver.FindElement(By.Id("selectProductSort"));
            //DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            //wait.Timeout = TimeSpan.FromSeconds(50);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            //Console.WriteLine("After wait : {0}", wait.Until(changeOfValue()));

            GenericHelper.WaitForWebElement(By.XPath("//*[@id='selectProductSort']/option[1]"), 10);
        }

        private Func<IWebElement, string> changeOfValue()
        {
            return ((x) =>
            {
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text == "Price: Lowest first")
                {
                    return select.SelectedOption.Text;
                }
                return null;
            });
        }
    }
}
