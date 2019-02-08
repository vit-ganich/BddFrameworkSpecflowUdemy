using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class BaseClass
    {
        public TestContext TestContext { get; set; }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            return options;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            //options.EnsureCleanSession = true;
            return options;
        }

        private static FirefoxProfile GetFirefoxOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();
            return manager.GetProfile("default"); ;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private static IWebDriver GetChromeDriver()
        {
            return new ChromeDriver(GetChromeOptions());
        }

        private static IWebDriver GetIEDriver()
        {
            return new InternetExplorerDriver(GetIEOptions());
        }

        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.IE:
                    ObjectRepository.Driver = GetIEDriver();
                    break;

                default:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
            }

            ObjectRepository.Driver.Manage().Timeouts()
                .PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());

            ObjectRepository.Driver.Manage().Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());

            BrowserHelper.BrowserMaximize();
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            if(ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Quit();
            }
        }

        [TestCleanup]
        public void AfterTest()
        {
            ScreenShotHelper.TakeScreenshot(TestContext.TestName);
        }
    }
}
