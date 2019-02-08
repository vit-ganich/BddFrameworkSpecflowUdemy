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
    public class TestTextBox : BaseClass
    {
        [TestMethod]
        public void TextBoxTest()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            TextBoxHelper.TypeInTextBox(By.Id("search_query_top"), ObjectRepository.Config.GetUserName());
            TextBoxHelper.ClearTextBox(By.Id("search_query_top"));
        }
    }
}
