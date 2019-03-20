using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

using System.Data;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class TestExcelData
    {
        [TestMethod]
        public void TestReadExcel()
        {
            //FileStream stream = new FileStream(@"E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestTable.xlsx", FileMode.Open, FileAccess.Read);
            //IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //DataTable table = reader.AsDataSet().Tables[0];

            //for (int i = 0; i < table.Rows.Count; i++){
            //    var col = table.Rows[i];
            //    for (int j = 0; j < col.ItemArray.Length; j++)
            //    {
            //        Console.Write("Data : {0}", col.ItemArray[j]);
            //    }
            //    Console.WriteLine(); 
            //}
            string excelPath = @"E:\Scripts\BddFrameworkSpecflowUdemy\DataDriven\TestData\TestVariosDataTypes.xlsx";
            int i = 0;
            while (i < 3)
            {
                Console.WriteLine(ExcelReaderHelper.GetCellData(excelPath, "Test", 0, i));
                i++;
            }
        }
    }
}
