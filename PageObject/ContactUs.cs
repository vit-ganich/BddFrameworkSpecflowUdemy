using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class ContactUs : PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "id_contact")]
        private IWebElement SubjectHeadingDropDown;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailAddressTextBox;

        [FindsBy(How = How.Id, Using = "id_order")]
        private IWebElement OrderReference;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement MessageTextBox;

        [FindsBy(How = How.Id, Using = "fileUpload")]
        private IWebElement ChooseFileButton;

        [FindsBy(How = How.Id, Using = "submitMessage")]
        private IWebElement SendButton;

        public ContactUs(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        public void ChooseSubjectHeading(string value)
        {
            if (value == "Customer service")
            {
                DropDownHelper.SelectElement(SubjectHeadingDropDown, value);
                return;
            }
            DropDownHelper.SelectElement(SubjectHeadingDropDown, "Webmaster");
            
        }

        public void EnterEmailAdress(string emailAddress)
        {
            EmailAddressTextBox.SendKeys(emailAddress);
        }
        public void EnterOrderReferense(string order)
        {
            OrderReference.SendKeys(order);
        }

        public void EnterMessage(string text)
        {
            MessageTextBox.SendKeys(text);
        }

        public void ClickSendMessage()
        {
            SendButton.Click();
            // Wait for the success message
            GenericHelper.WaitForWebElementInPage(By.XPath("//*[contains(text(),'successfully sent')]"), timeout: 30);
        }

        public new HomePage SignOut()
        {
            base.SignOut();
            return new HomePage(driver);
        }
    }
}
