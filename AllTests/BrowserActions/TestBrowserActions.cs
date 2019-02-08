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
    public class TestBrowserActions
    {
        [TestMethod]
        public void TestActions()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            // Without the Helper Methods

            //ObjectRepository.Driver.Manage().Window.Maximize();
            //GenericHelper.GetElement(By.XPath(("(//a[text()='Dresses'])[2]"))).Click();
            //System.Threading.Thread.Sleep(2000);
            //ObjectRepository.Driver.Navigate().Back();
            //System.Threading.Thread.Sleep(2000);
            //ObjectRepository.Driver.Navigate().Forward();
            //System.Threading.Thread.Sleep(2000);
            //ObjectRepository.Driver.Navigate().Refresh();
            //System.Threading.Thread.Sleep(5000);


            GenericHelper.GetElement(By.XPath(("(//a[text()='Dresses'])[2]"))).Click();
            System.Threading.Thread.Sleep(2000);
            BrowserHelper.GoBack();
            System.Threading.Thread.Sleep(2000);
            BrowserHelper.GoForward();
            System.Threading.Thread.Sleep(2000);
            BrowserHelper.RefreshPage();
            System.Threading.Thread.Sleep(2000);
            BrowserHelper.BrowserMinimize();
        }
    }
}
