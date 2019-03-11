using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BddFrameworkSpecflowUdemy
{
    public class DropDownHelper
    {
        private static SelectElement select;

        public static void SelectElement(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);
            Console.WriteLine("Selected index : {0}", select.SelectedOption.Text);
        }

        public static void SelectElement(By locator, string text, bool byValue = false)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            if (!byValue)
            {
                select.SelectByText(text);
                Console.WriteLine("Selected text : {0}", select.SelectedOption.Text);
            }
            else
            {
                select.SelectByValue(text);
                Console.WriteLine("Selected value : {0}", select.SelectedOption.GetAttribute("value"));
            }

        }

        public static void SelectElement(IWebElement element, string text, bool byValue = false)
        {
            select = new SelectElement(element);
            if (!byValue)
            {
                select.SelectByText(text);
                Console.WriteLine("Selected text : {0}", select.SelectedOption.Text);
            }
            else
            {
                select.SelectByValue(text);
                Console.WriteLine("Selected value : {0}", select.SelectedOption.GetAttribute("value"));
            }

        }

        public static IList<string> GetAllItemsText(By locator)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));

            return select.Options.Select((x) => x.Text).ToList();
        }
    }
}
