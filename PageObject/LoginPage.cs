using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class LoginPage : PageBase
    {
        private IWebDriver driver;

        // Note: Page Factory is obsolete
        #region Implementation using Page Factory

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement LoginTextBox;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement PasswordTextBox;

        [FindsBy(How = How.Name, Using = "SubmitLogin")]
        private IWebElement SignInButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='My Store']")]
        private IWebElement HomePageLink;


        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        public MyAccount SignIn(string username, string password)
        {
            LoginTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
            SignInButton.Click();
            return new MyAccount(driver);
        }

        #endregion


        #region Implementation without Page Factory

        //private By LoginTextBox = By.Id("email");
        //private By PasswordTextBox = By.Id("passwd");
        //private By SignInButton = By.Name("SubmitLogin");
        //private By HomePageLink = By.XPath("//a[@title='My Store']");


        //public MyAccount SignIn(string username, string password)
        //{
        //    ObjectRepository.Driver.FindElement(LoginTextBox).SendKeys(username);
        //    ObjectRepository.Driver.FindElement(PasswordTextBox).SendKeys(password);
        //    ObjectRepository.Driver.FindElement(SignInButton).Click();
        //    return new MyAccount();
        //}

        //public HomePage NavigateToHome()
        //{
        //    ObjectRepository.Driver.FindElement(HomePageLink).Click();
        //    return new HomePage();
        //}

        #endregion
    }
}