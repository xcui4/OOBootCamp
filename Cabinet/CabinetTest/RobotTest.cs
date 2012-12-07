using System.Collections.Generic;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CabinetTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Store_One_Bag_When_All_Cabinets_Full_Return_Null_Ticket()
        {
            var robot = new Robot();
            List<int> emptyCaibet = new List<int> {0, 0, 0};
            robot.Setup(emptyCaibet);
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Assert.IsNull(ticket);
        }

        [TestMethod]
        public void Store_One_Bag_When_Not_All_Cabinets_Full_Return_Ticket()
        {
            var robot = new Robot();
            List<int> emptyCaibet = new List<int> { 0, 1, 0 };
            robot.Setup(emptyCaibet);
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Assert.IsNotNull(ticket);
        }
      
    }


}