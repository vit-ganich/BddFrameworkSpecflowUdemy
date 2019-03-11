using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class HomePage : PageBase
    {
        private IWebDriver driver;

        // Note: Page Factory is obsolete
        #region Implementation using Page Factory

        [FindsBy(How = How.Id, Using = "search_query_top")]
        private IWebElement SearchTextBox;

        [FindsBy(How = How.Name, Using = "submit_search")]
        private IWebElement SubmitSearchButton;

        [FindsBy(How = How.ClassName, Using = "login")]
        private IWebElement LogInLink;

        
        public HomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

    public void QuickSearch(string text)
        {
            SearchTextBox.SendKeys(text);
            SubmitSearchButton.Click();
        }

        public LoginPage NavigateToLogin()
        {
            LogInLink.Click();
            return new LoginPage(driver);
        }

        #endregion

        #region Implementation without Page Factory

        //private By SearchTextBox = By.Id("search_query_top");
        //private By SubmitSearchButton = By.Name("submit_search");
        //private By LogInLink = By.ClassName("login");


        //public void QuickSearch(string text)
        //{
        //    ObjectRepository.Driver.FindElement(SearchTextBox).SendKeys(text);
        //    ObjectRepository.Driver.FindElement(SubmitSearchButton).Click();
        //}

        //public LoginPage NavigateToLogin()
        //{
        //    ObjectRepository.Driver.FindElement(LogInLink).Click();
        //    return new LoginPage();
        //}

        #endregion
    }
}
