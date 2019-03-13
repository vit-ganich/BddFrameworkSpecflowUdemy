using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddFrameworkSpecflowUdemy.AllTests
{
    [TestClass]
    public class TestContextClass
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value;  }
        }

        [TestMethod]
        public void TestCase1()
        {
            Console.WriteLine("Test name : {0}", TestContext.TestName);
        }

        [TestMethod]
        public void TestCase2()
        {
            Console.WriteLine("Test name : {0}", TestContext.TestName);
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("Test result : {0}", TestContext.CurrentTestOutcome);
        }
    }
}
