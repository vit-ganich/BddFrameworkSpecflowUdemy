using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    class RadioButtonHelper
    {
        private static IWebElement element;
        public static void ClickRadioButton(By locator)
        {
            if (!IsRadioButtonSelected(locator))
            {
                element.Click();
            }
        }

        public static bool IsRadioButtonSelected(By locator)
        {
            element = GenericHelper.GetElement(locator);

            string flag = element.GetAttribute("checked");

            if (flag != null)
            {
                return flag.Equals("true") || flag.Equals("checked");
            }
            return false;
        }
    }
}
