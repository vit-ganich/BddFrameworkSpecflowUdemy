using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy
{
    [TestClass]
    public class TestKeywordDriven
    {
        [TestMethod]
        public void TestKeyword()
        {
            DataEngine keyDataEngine = new DataEngine();

            keyDataEngine.ExecuteScript(@"E:\Scripts\BddFrameworkSpecflowUdemy\AllTests\KeywordDrivenTest\TestData\Keywords.xlsx", "TC01");
        }
    }
}
