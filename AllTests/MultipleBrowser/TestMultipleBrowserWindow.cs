using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.AllTests
{
    [TestClass]
    public class TestMultipleBrowserWindow
    {
        [TestMethod]
        public void TestMultipleBrowser()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");

            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));

            BrowserHelper.SwitchToWindow(0);

            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));

            BrowserHelper.SwitchToParentWindow();
        }

        [TestMethod]
        public void TestMultipleFrames()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");

            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));

            BrowserHelper.SwitchToWindow(1);

            // This button is location on the other frame, so we need to switch the frame
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));

            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));

            // And we need to return to the main frame
            ObjectRepository.Driver.SwitchTo().DefaultContent();

            ButtonHelper.ClickButton(By.XPath("//button[text()='Run »']"));
        }
    }
}
