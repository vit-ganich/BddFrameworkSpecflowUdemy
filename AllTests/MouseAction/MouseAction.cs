using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.AllTests.MouseAction
{
    [TestClass]
    public class MouseAction
    {
        [TestMethod]
        public void TestContextClick()
        {
            NavigationHelper.NavigateToUrl("https://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);

            IWebElement element = ObjectRepository.Driver.FindElement(By.Id("draggable"));

            act.ContextClick(element)
                .Build()
                .Perform();

            Thread.Sleep(5000);
        }

        [TestMethod]
        public void DragDropTest()
        {
            NavigationHelper.NavigateToUrl("https://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);

            IWebElement elementDraggable = ObjectRepository.Driver.FindElement(By.Id("draggable"));
            IWebElement elementTarget = ObjectRepository.Driver.FindElement(By.Id("droptarget"));

            act.DragAndDrop(elementDraggable, elementTarget).Build().Perform();

            Thread.Sleep(5000);
        }

        [TestMethod]
        public void TestClickAndHold()
        {
            NavigationHelper.NavigateToUrl("https://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement elementDraggable = ObjectRepository.Driver.FindElement(By.XPath("//li[text()='Pushing Me Away ']"));
            IWebElement elementTarget = ObjectRepository.Driver.FindElement(By.XPath("//li[text()='Papercut ']"));

            act.ClickAndHold(elementDraggable)
                .MoveToElement(elementTarget)
                .Release()
                .Build()
                .Perform();

            Thread.Sleep(5000);

        }

        [TestMethod]
        public void TestKeyboardAction()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            Actions act = new Actions(ObjectRepository.Driver);

            act.KeyDown(Keys.LeftControl)
                .SendKeys("t")
                .KeyUp(Keys.LeftControl)
                .Build()
                .Perform();

            Thread.Sleep(5000);
        }
    }
}
