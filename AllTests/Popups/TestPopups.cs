using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class TestPopups
    {
        [TestMethod]
        public void TestAlert()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");

            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));

            BrowserHelper.SwitchToWindow(1);

            // This button is location on the other frame, so we need to switch the frame
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));

            // Click to the alert button
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));

            IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();

            string text = alert.Text;
            System.Threading.Thread.Sleep(1000);
            alert.Accept();
            System.Threading.Thread.Sleep(1000);
            ObjectRepository.Driver.SwitchTo().DefaultContent();
        }
    }
}
