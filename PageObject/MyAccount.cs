using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BddFrameworkSpecflowUdemy
{
    public class MyAccount : PageBase
    {
        private IWebDriver driver;

        // Note: Page Factory is obsolete
        #region Implementation using Page Factory

        [FindsBy(How = How.XPath, Using = "//a[@title='Home']")]
        private IWebElement HomePageBottomButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Information']")]
        private IWebElement MyPersonalInfoLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='Orders']")]
        private IWebElement OrderHistoryAndDetailsLink;


        public MyAccount(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        public HomePage GoToHomeBottom()
        {
            HomePageBottomButton.Click();
            return new HomePage(driver);
        }

        #endregion


        public YourPersonalInformation NavigateToMyPersonalInfo()
        {
            MyPersonalInfoLink.Click();
            return new YourPersonalInformation(driver);
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
