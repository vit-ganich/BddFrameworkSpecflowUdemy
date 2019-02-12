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

            //IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();

            //alert.Accept();

            string text = JSPopupHelper.GetPopUpText();
            JSPopupHelper.ClickAcceptOnPopUp();
            Console.WriteLine(text);
        }

        [TestMethod]
        public void TestConfirmationPopUp()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/code/tryit.asp?filename=G13MNQ8NUAXV");

            ButtonHelper.ClickButton(By.XPath("//*[text()='Run »']"));

            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));

            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));

            var text = JSPopupHelper.GetPopUpText();

            JSPopupHelper.ClickAcceptOnPopUp();

            //IAlert confirm = ObjectRepository.Driver.SwitchTo().Alert();

            //confirm.Accept();

            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));

            JSPopupHelper.ClickDismissOnPopUp();

            //confirm = ObjectRepository.Driver.SwitchTo().Alert();

            //confirm.Dismiss();

            ObjectRepository.Driver.SwitchTo().DefaultContent();
            Console.WriteLine(text);
        }

        [TestMethod]
        public void TestPromptPopUp()
        {
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));

            //IAlert prompt = ObjectRepository.Driver.SwitchTo().Alert();

            //prompt.SendKeys("This Is SPARTAAAAAAA!!!!!!!!!!!!!!!");

            //prompt.Accept();

            string text = JSPopupHelper.GetPopUpText();
            JSPopupHelper.SendKeysToPopUp(text);
            JSPopupHelper.ClickAcceptOnPopUp();
        }
    }
}
