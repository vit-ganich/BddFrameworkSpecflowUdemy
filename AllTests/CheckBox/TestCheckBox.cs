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
    public class TestCheckBox : BaseClass
    {
        [TestMethod]
        public void CheckBoxTest()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            LinkHelper.ClickLink(By.LinkText("Women"));

            IWebElement element = ObjectRepository.Driver.FindElement(By.Id("layered_category_4"));


            Console.WriteLine(CheckBoxHelper.IsCheckBoxChecked(By.Id("layered_category_4")));
            CheckBoxHelper.CheckedCheckBox(By.Id("layered_category_4"));
            Console.WriteLine(CheckBoxHelper.IsCheckBoxChecked(By.Id("layered_category_4")));
            CheckBoxHelper.CheckedCheckBox(By.Id("layered_category_4"));
            //element.Click();
            //System.Threading.Thread.Sleep(1000);
        }
    }
}
