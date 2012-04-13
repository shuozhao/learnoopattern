using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnOOInterface.Composite;

namespace TestOODesignPattern.TestComposite
{
    /// <summary>
    /// Summary description for TestIdentifyMap
    /// </summary>
    [TestClass]
    public class TestIdentifyMap
    {
        public TestIdentifyMap()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSimpleObjectMap()
        {
            IdentityMap<SimpleObject> simpleMap = new IdentityMap<SimpleObject>();

            simpleMap.Add(new SimpleObject(), Guid.NewGuid());
            simpleMap.Add(new SimpleObject(), Guid.NewGuid());
            simpleMap.Add(new SimpleObject(), Guid.NewGuid());
            simpleMap.Add(new SimpleObject(), Guid.NewGuid());

            foreach (SimpleObject curObj in simpleMap.GetEnumerable())
            {
                Console.WriteLine(curObj.ToString());
            }
        }

        class SimpleObject
        {
            public static Int32 instanceCount = 0;

            public override string  ToString()
            {
 	             return (SimpleObject.instanceCount++).ToString();
            }
        }
    }
}
