using System.Collections.Generic;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CabinetTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Store_One_Bag_When_All_Cabinets_Full_Return_Null_Ticket()
        {
            List<Cabinet> emptyCabinetList = new List<Cabinet> { new Cabinet(0) };
            var robot = new Robot(emptyCabinetList);
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Assert.IsNull(ticket);
        }

        [TestMethod]
        public void Store_One_Bag_When_Not_All_Cabinets_Full_Return_Ticket()
        {
            List<Cabinet> notEmptyCabinetList = new List<Cabinet> { new Cabinet(1) };
            var robot = new Robot(notEmptyCabinetList);
            
            var bag = new Bag();
            var ticket = robot.Store(bag);
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void Store_One_Bag_Return_Correct_Ticket_When_Not_All_Cabinets_Full()
        {
            List<Cabinet> notEmptyCabinetList = new List<Cabinet> { new Cabinet(1) };

            var robot = new Robot(notEmptyCabinetList);

            var bag = new Bag();
            var ticket = robot.Store(bag);
            var returnBag = robot.Pick(ticket);
            Assert.AreEqual(bag, returnBag);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTicketException), "Invalid Ticket")]
        public void Should_Give_Correct_Information_When_Invalid_Ticket_Passed_To_Robot()
        {
            List<Cabinet> notEmptyCabinetList = new List<Cabinet> { new Cabinet(1) };
            var robot = new Robot(notEmptyCabinetList);

            var invalidTicket = new Ticket();

            robot.Pick(invalidTicket);
        }
    }
}