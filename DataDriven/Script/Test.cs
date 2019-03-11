using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.DataDriven.Script
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestContactUs()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            ContactUs contactUsPage = homePage.NavigateToContactUs();

            contactUsPage.ChooseSubjectHeading("Customer service");
            contactUsPage.EnterEmailAdress("test@test.test");
            contactUsPage.EnterOrderReferense("1");
            contactUsPage.EnterMessage("Test message 1234567890");
            contactUsPage.ClickSendMessage();
        }
    }
}
