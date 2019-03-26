using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    public class DataEngine
    {
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameter;

        public DataEngine(int keywordCol = 2, int locatorTypeCol = 3, int locatorValueCol = 4, int parameter = 5)
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
                case "select":
                    DropDownHelper.SelectElement(locator, args[0]);
                    break;
                default:
                    throw new NoSuchKeywordFoundException("Oh no! Keyword not found... I'm sorry...");
            }
        }

        public void ExecuteScript(string excelPath, string sheetName)
        {
            int totalRows = ExcelReaderHelper.GetTotalRows(excelPath, sheetName);

            for (int i = 1; i < totalRows; i++)
            {
                var locatorType = ExcelReaderHelper.GetCellData(excelPath, sheetName, i, _locatorTypeCol).ToString();
                var locatorValue = ExcelReaderHelper.GetCellData(excelPath, sheetName, i, _locatorValueCol).ToString();
                var keyword = ExcelReaderHelper.GetCellData(excelPath, sheetName, i, _keywordCol).ToString();
                var parameter = ExcelReaderHelper.GetCellData(excelPath, sheetName, i, _parameter).ToString();

                PerformAction(keyword, locatorType, locatorValue, parameter);
            }
        }
    }
}
