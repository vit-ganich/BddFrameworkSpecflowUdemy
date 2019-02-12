using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class JSPopupHelper
    {
        public static bool IsPopUpPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopUpText()
        {
            if (IsPopUpPresent())
            {
                return ObjectRepository.Driver.SwitchTo().Alert().Text;
            }
            return string.Empty;
        }

        public static void ClickAcceptOnPopUp()
        {
            if (IsPopUpPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().Accept();
            }
        }

        public static void ClickDismissOnPopUp()
        {
            if (IsPopUpPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
            }
        }

        public static void SendKeysToPopUp(string text)
        {
            if (IsPopUpPresent())
            {
                ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
            }
        }
    }
}
