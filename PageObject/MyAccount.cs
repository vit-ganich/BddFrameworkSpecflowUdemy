using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BddFrameworkSpecflowUdemy
{
    public class MyAccount
    {
        // Note: Page Factory is obsolete
        #region Implementation using Page Factory

        [FindsBy(How = How.XPath, Using = "//a[@title='Home']")]
        private IWebElement HomePageButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Information']")]
        private IWebElement MyPersonalInfoLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='Orders']")]
        private IWebElement OrderHistoryAndDetailsLink;


        public MyAccount()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        public HomePage NavigateToHome()
        {
            HomePageButton.Click();
            return new HomePage();
        }

        #endregion


        public YourPersonalInformation NavigateToMyPersonalInfo()
        {
            MyPersonalInfoLink.Click();
            return new YourPersonalInformation();
        }

        #region Implementation without Page Factory
        //#region WebElements

        //private By HomePageButton = By.XPath("//a[@title='Home']");
        //private By MyPersonalInfoLink = By.XPath("//a[@title='Information']");
        //private By OrderHistoryAndDetailsLink = By.XPath("//a[@title='Orders']");
        //#endregion

        //public HomePage NavigateToHome()
        //{
        //    ObjectRepository.Driver.FindElement(HomePageButton).Click();
        //    return new HomePage();
        //}

        //public YourPersonalInformation NavigateToMyPersonalInfo()
        //{
        //    ObjectRepository.Driver.FindElement(MyPersonalInfoLink).Click();
        //    return new YourPersonalInformation();
        //}
        #endregion
    }
}
