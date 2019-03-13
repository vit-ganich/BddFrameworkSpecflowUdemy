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
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestTable.csv", "TestTable#CSV", DataAccessMethod.Sequential)]
        public void TestContactUs()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            ContactUs contactUsPage = homePage.NavigateToContactUs();

            contactUsPage.ChooseSubjectHeading(TestContext.DataRow["Subject"].ToString());
            contactUsPage.EnterEmailAddress(TestContext.DataRow["EmailAddress"].ToString());
            contactUsPage.EnterOrderReferense(TestContext.DataRow["OrderReference"].ToString());
            contactUsPage.EnterMessage(TestContext.DataRow["Message"].ToString());
            System.Threading.Thread.Sleep(2000);
            contactUsPage.ClickSendMessage();
        }
    }
}
