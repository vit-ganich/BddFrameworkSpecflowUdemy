using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BddFrameworkSpecflowUdemy.AllTests.Button
{
    [TestClass]
    public class HandleButton : BaseClass
    {
        [TestMethod]
        public void TestButton()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());
            LinkHelper.ClickLink(By.LinkText("Women"));
        }
    }
}
