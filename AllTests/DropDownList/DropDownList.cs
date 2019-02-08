using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class DropDownList : BaseClass
    {
        [TestMethod]
        public void TestDropDownList()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());
            LinkHelper.ClickLink(By.LinkText("Women"));

            DropDownHelper.SelectElement(By.Id("selectProductSort"), 1);

            DropDownHelper.SelectElement(By.Id("selectProductSort"), "Product Name: A to Z");

            DropDownHelper.SelectElement(By.Id("selectProductSort"), "reference:asc", true);

            foreach (var el in DropDownHelper.GetAllItemsText(By.Id("selectProductSort")))
            {
                Console.WriteLine(el);
            }
            
        }
    }
}
