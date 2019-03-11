using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class YourPersonalInformation : PageBase
    {
        private IWebDriver driver;

        // Note: Page Factory is obsolete
        #region Implementation using Page Factory

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/descendant::span[9]")]
        private IWebElement BackToYourAccountLink;


        public YourPersonalInformation(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        public MyAccount NavigateBackToYourAccount()
        {
            BackToYourAccountLink.Click();
            return new MyAccount(driver);
        }


        #endregion


        #region Implementation without Page Factory

        //private By BackToYourAccountLink = By.XPath("//*[@id='center_column']/descendant::span[9]");


        //public MyAccount NavigateBackToYourAccount()
        //{
        //    ObjectRepository.Driver.FindElement(BackToYourAccountLink).Click();
        //    return new MyAccount();
        //}

        #endregion
    }
}
