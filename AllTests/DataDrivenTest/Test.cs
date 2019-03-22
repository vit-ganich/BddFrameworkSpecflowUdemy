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

        /// <summary>
        /// Reading data from CSV-file
        /// </summary>
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestTable.csv", "TestTable#CSV", DataAccessMethod.Sequential)]
        public void TestDataDrivenCSV()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            ContactUs contactUsPage = homePage.ClickContactUsLink();

            contactUsPage.ChooseSubjectHeading(TestContext.DataRow["Subject"].ToString());
            contactUsPage.EnterEmailAddress(TestContext.DataRow["EmailAddress"].ToString());
            contactUsPage.EnterOrderReferense(TestContext.DataRow["OrderReference"].ToString());
            contactUsPage.EnterMessage(TestContext.DataRow["Message"].ToString());
            contactUsPage.ClickSendMessage();
        }

        /// <summary>
        /// Reading data from XML-file
        /// </summary>
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestTable.xml", "MessageDetails", DataAccessMethod.Sequential)]
        public void TestDataDrivenXML()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            ContactUs contactUsPage = homePage.ClickContactUsLink();

            contactUsPage.ChooseSubjectHeading(TestContext.DataRow["Subject"].ToString());
            contactUsPage.EnterEmailAddress(TestContext.DataRow["EmailAddress"].ToString());
            contactUsPage.EnterOrderReferense(TestContext.DataRow["OrderReference"].ToString());
            contactUsPage.EnterMessage(TestContext.DataRow["Message"].ToString());
            contactUsPage.ClickSendMessage();
        }

        /// <summary>
        /// Reading data from Excel-file
        /// </summary>
        [TestMethod]
        [DataSource("System.Data.Odbc", @"Dsn=Excel Files;dbq=E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestTable.xlsx;", "TestExcelData$", DataAccessMethod.Sequential)]
        public void TestDataDrivenExcel()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            ContactUs contactUsPage = homePage.ClickContactUsLink();

            contactUsPage.ChooseSubjectHeading(TestContext.DataRow["Subject"].ToString());
            contactUsPage.EnterEmailAddress(TestContext.DataRow["EmailAddress"].ToString());
            contactUsPage.EnterOrderReferense(TestContext.DataRow["OrderReference"].ToString());
            contactUsPage.EnterMessage(TestContext.DataRow["Message"].ToString());
            contactUsPage.ClickSendMessage();
        }

        [TestMethod]
        public void TestDataDrivenExcelReaderHelper()
        {
            string excelPath = @"E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestTable.xlsx";
            string sheetName = "TestExcelData";
            // Open the landing page
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            HomePage homePage = new HomePage(ObjectRepository.Driver);

            ContactUs contactUsPage = homePage.ClickContactUsLink();

            //contactUsPage.ChooseSubjectHeading(TestContext.DataRow["Subject"].ToString());
            //contactUsPage.EnterEmailAddress(TestContext.DataRow["EmailAddress"].ToString());
            //contactUsPage.EnterOrderReferense(TestContext.DataRow["OrderReference"].ToString());
            //contactUsPage.EnterMessage(TestContext.DataRow["Message"].ToString());

            contactUsPage.ChooseSubjectHeading(ExcelReaderHelper.GetCellData(excelPath, sheetName, 1, 0).ToString());
            contactUsPage.EnterEmailAddress(ExcelReaderHelper.GetCellData(excelPath, sheetName, 1, 1).ToString());
            contactUsPage.EnterOrderReferense(ExcelReaderHelper.GetCellData(excelPath, sheetName, 1, 2).ToString());
            contactUsPage.EnterMessage(ExcelReaderHelper.GetCellData(excelPath, sheetName, 1, 3).ToString());

            contactUsPage.ClickSendMessage();
        }

    }
}
