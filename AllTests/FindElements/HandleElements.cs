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
    public class HandleElements
    {
        [TestMethod]
        public void TestGetElements()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            //IReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.XPath("//li[starts-with(@class,'htmlcontent')]"));

            foreach(var el in GenericHelper.GetElements(By.XPath("//li[starts-with(@class,'htmlcontent')]")))
            {
                Console.WriteLine(el.GetAttribute("text"));
            }
        }
    }
}
