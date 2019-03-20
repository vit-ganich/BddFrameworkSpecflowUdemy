using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace BddFrameworkSpecflowUdemy
{
    public class ExcelReaderHelper
    {
        private static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        private static IExcelDataReader GetExcelReader(string excelPath, string sheetName)
        {
            if(_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                stream = new FileStream(excelPath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName, reader);
            }
            return reader;
        }

        public static int GetTotalRows(string excelPath, string sheetName)
        {
            IExcelDataReader _reader = GetExcelReader(excelPath, sheetName);
            return _reader.AsDataSet().Tables[sheetName].Rows.Count;
        }

        public static object GetCellData(string excelPath, string sheetName, int row, int column)
        {
            IExcelDataReader _reader = GetExcelReader(excelPath, sheetName);

            DataTable table = _reader.AsDataSet().Tables[sheetName];
            var result = table.Rows[row][column];
            return GetData(result.GetType(), result);
        }

        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            }
        }
    }
}
