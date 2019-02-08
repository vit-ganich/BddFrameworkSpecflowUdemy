using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace BddFrameworkSpecflowUdemy
{
    public class CheckBoxHelper
    {
        private static IWebElement element;
        public static void CheckedCheckBox(By locator)
        {
            if (!IsCheckBoxChecked(locator))
            {
                element.Click();
            }
        }

        public static bool IsCheckBoxChecked(By locator)
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
