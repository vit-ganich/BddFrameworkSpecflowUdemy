using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@title='My Store']")]
        private IWebElement HomeLink;

        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        protected void SignOut()
        {
            By signOutButton = By.ClassName("logout");
            if (GenericHelper.IsElementPresent(signOutButton))
            {
                ButtonHelper.ClickButton(signOutButton);
            }
        }

        protected void NavigateToHomePage()
        {
            HomeLink.Click();
        }
    }
}
