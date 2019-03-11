using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class TestPageObject
    {
        [TestMethod]
        public void TestPage()
        {
            string username = ObjectRepository.Config.GetUserName();
            string passw = ObjectRepository.Config.GetPassWord();

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            LoginPage loginPage = homePage.NavigateToLogin();

            MyAccount accountPage = loginPage.SignIn(username, passw);

            YourPersonalInformation myPersonalInfoPage = accountPage.NavigateToMyPersonalInfo();

            accountPage = myPersonalInfoPage.NavigateBackToYourAccount();

            homePage = accountPage.GoToHomeBottom();

        }
    }
}
