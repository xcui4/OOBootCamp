using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetTest
{
    /// <summary>
    /// Summary description for RobotTest
    /// </summary>
    [TestClass]
    public class RobotTest
    {
   
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
        public void HasAvailableBoxWhenThereIsEmptyBoxInFirstCabinet()
        {
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(0);
            var robot = new Robot();
            robot.AddCabinet(cabinet1);
            robot.AddCabinet(cabinet2);
            Assert.IsTrue(robot.HasEmptyBox);

        }

        [TestMethod]
        public void ShouldReturnTicketGivenBoxAvailableWhenStoreBagByRobot()
        {
            var cabinet = new Cabinet(1);
            var bag = new Bag();
            Robot robot = new Robot();
            robot.AddCabinet(cabinet);
            var ticket = robot.Store(bag);

            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        [ExpectedException(typeof(NoBoxAvailableException))]
        public void ShouldThrowNoEmptyBoxWhenAllCabinetsAreFull()
        {
            var cabinet = new Cabinet(0);
            var bag = new Bag();
            Robot robot = new Robot();
            robot.AddCabinet(cabinet);
            var ticket = robot.Store(bag);

            Assert.IsNotNull(ticket);
        }
    }
}
