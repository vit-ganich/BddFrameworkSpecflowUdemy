using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.AllTests
{
    [TestClass]
    public class TestFileUpload
    {
        [TestMethod]
        public void TestUpload()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            LinkHelper.ClickLink(By.XPath("//*[@title='Contact Us']"));

            ButtonHelper.ClickButton(By.Id("fileUpload"));

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = @"E:\Scripts\BddFrameworkSpecflowUdemy\AutoIT\UploadFile.exe";
            processInfo.Arguments = @"E:\Scripts\BddFrameworkSpecflowUdemy\AllTests\FileUploadTest\TestData\FileToUpload.txt";

            Process process = Process.Start(processInfo);
            process.WaitForExit();
            process.Close();
        }
    }
}
