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

            string autoITscriptLocation = @"E:\Scripts\BddFrameworkSpecflowUdemy\AutoIT\UploadFile.exe";
            string pathToUploadFile = @"E:\Scripts\BddFrameworkSpecflowUdemy\AllTests\FileUploadTest\TestData\FileToUpload.txt";

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebSiteUrl());

            LinkHelper.ClickLink(By.XPath("//*[@title='Contact Us']"));

            /**
             * Firefox Gecko driver cannot click on input element with type “file”
             * See StackOwerflow: https://stackoverflow.com/questions/52411584/firefox-gecko-driver-cannot-click-on-input-element-with-type-file
             * 
             * Firefox (via geckodriver) is behaving correctly here and Chrome is not. 
             * The W3C WebDriver Specification, in its description of the Element Click 
             * algorithm in Section 14.1, step 3 states: 
             * “If the element is an input element in the file upload state1 return error 
             * with error code invalid argument.”
             * 
             * To successfully upload files using WebDriver, 
             * you should use the sendKeys method with the full path to the file you want to upload.
             **/

            if (ObjectRepository.Config.GetBrowser() == BrowserType.Chrome)
            {
                ButtonHelper.ClickButton(By.Id("fileUpload"));
                ProcessStartInfo processInfo = new ProcessStartInfo()
                {
                    FileName = autoITscriptLocation,
                    Arguments = pathToUploadFile
                };

                using (Process process = Process.Start(processInfo))
                {
                    process.WaitForExit();
                }
            }
            else
            {
                TextBoxHelper.TypeInTextBox(By.Id("fileUpload"), pathToUploadFile);
            }

            System.Threading.Thread.Sleep(1000);
        }
    }
}
