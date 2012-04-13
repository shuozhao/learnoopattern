using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnOOInterface.Command;
using System.IO;

namespace TestOODesignPattern
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestCommandPattern
    {
        public TestCommandPattern()
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
        public void TestNullObjectParameterCommand()
        {
            DelegateCommand<object, object> testMessageOutputCommand = new
                DelegateCommand<object, object>(WriteTestMessage, null, null);

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testMessageOutputCommand.Execute();
                Assert.AreEqual("is that working??!!"+ Environment.NewLine, writer.ToString());
            }
        }

        private bool WriteTestMessage(object dummy1, object dummy2)
        {
            Console.WriteLine("is that working??!!");
            return true;
        }

        [TestMethod]
        public void TestTwoParameterCommand()
        {
            TestReceiver receiver1 = new TestReceiver();
            ICommand testMessageOutputCommand = new
                DelegateCommand<string, string>(receiver1.ReceiverAction, "hello", "yunyun");

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                testMessageOutputCommand.Execute();
                Assert.AreEqual("hellois that working yunyun" + Environment.NewLine, writer.ToString());
            }
        }

        internal class TestReceiver
        {
            public bool ReceiverAction(string name, string working)
            {
                Console.WriteLine(name + "is that working " + working);

                return true;
            }
        }
    }
}
