using System;
using System.Collections.Generic;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetTest
{
    [TestClass]
    public class SmartRobotTest
    {
        
        [TestMethod]
        public void Store_One_Bag_When_All_Cabinets_Full_Return_Null_Ticket()
        {
            List<Cabinet> emptyCabinetList = new List<Cabinet> { new Cabinet(0) };
            var robot = new SmartRobot(emptyCabinetList);
            
            var ticket = robot.Store(new Bag());

            Assert.IsNull(ticket);
        }

        [TestMethod]
        public void Return_Ticket_When_Seats_Available()
        {
            var oneseatcabinet = new Cabinet(1);
            var twoseatscabinet = new Cabinet(2);
            List<Cabinet> cabinets = new List<Cabinet> { oneseatcabinet, twoseatscabinet };
            var robot = new SmartRobot(cabinets);

            var ticket = robot.Store(new Bag());

            Assert.IsNotNull(ticket);
            Assert.IsFalse(oneseatcabinet.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTicketException), "Invalid Ticket")]
        public void Should_Give_Correct_Information_When_Invalid_Ticket_Passed_To_Robot()
        {
            List<Cabinet> notEmptyCabinetList = new List<Cabinet> { new Cabinet(1) };
            var robot = new SmartRobot(notEmptyCabinetList);

            var invalidTicket = new Ticket();

            robot.Pick(invalidTicket);
        }
    }
}
