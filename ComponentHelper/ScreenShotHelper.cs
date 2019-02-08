using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    class ScreenShotHelper
    {
        #region Properties
        /// <summary>
        /// current timestamp to make run folder unique
        /// </summary>
        private static string runTimeStamp;

        /// <summary>
        /// returns current run folder name
        /// </summary>
        private static string RunFolder
        {
            get
            {
                if (runTimeStamp == null)
                    runTimeStamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
                return runTimeStamp;
            }
        }

        /// <summary>
        /// returns path to current solution
        /// </summary>
        public static string SolutionPath
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (path.Contains("TestResults"))
                    return path.Substring(0, path.IndexOf("TestResults") - 1);
                else
                    return path.Substring(0, path.IndexOf("bin") - 1);
            }
        }
        #endregion

        /// <summary>
        /// Method creates a folder in \TestResults\Screenshots\ with a timestamp and saves screenshot
        /// </summary>
        /// <param name="testName">combined time and a method name (optionally)</param>
        public static void TakeScreenshot(string testName="ScreenShot")
        {
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();

            string screenShotsFolder = SolutionPath + "\\TestResults\\ScreenShots\\" + RunFolder;

            if (!(Directory.Exists(screenShotsFolder)))
            {
                Directory.CreateDirectory(screenShotsFolder);
            }

            string screenShotName = string.Format("{0}_{1}.jpg", DateTime.Now.ToString("HH-mm-ss"), testName);

            string fullPathToScreenShot = Path.Combine(screenShotsFolder, screenShotName);

            screen.SaveAsFile(fullPathToScreenShot, ScreenshotImageFormat.Jpeg);
        }
    }
}
