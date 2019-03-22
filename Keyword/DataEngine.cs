using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.Keyword
{
    public class DataEngine
    {
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameter;

        public DataEngine(int keywordCol, int locatorTypeCol, int locatorValueCol, int parameter)
        {
            this._keywordCol = keywordCol;
            this._locatorTypeCol = locatorTypeCol;
            this._locatorValueCol = locatorValueCol;
            this._parameter = parameter;
        }

        private By GetElementLocator(string locatorType, string locatorValue)
        {
            switch (locatorType.ToLower().Trim())
            {
                case "classname":
                    return By.ClassName(locatorValue);
                case "cssselector":
                    return By.CssSelector(locatorValue);
                case "id":
                    return By.Id(locatorValue);
                case "name":
                    return By.Name(locatorValue);
                default:
                    return By.XPath(locatorValue);
            }
        }

        public void PerformAction(string keyword, string locatorType, string locatorValue, params string[] args)
        {
            By locator = GetElementLocator(locatorType, locatorValue);
            int timeout = 20;
            switch (keyword.ToLower().Trim())
            {
                case "click":
                    ButtonHelper.ClickButton(locator);
                    return;
                case "sendkeys":
                    TextBoxHelper.TypeInTextBox(locator, args[0]);
                    return;
                case "waitforelem":
                    GenericHelper.WaitForWebElementInPage(locator, timeout);
                    return;
                case "navigate":
                    NavigationHelper.NavigateToUrl(args[0]);
                    return;
                default:
                    throw new NoSuchKeywordFoundException("Oh no! Keyword not found... I'm sorry...");
            }
        }
    }
}
