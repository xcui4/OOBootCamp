using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetTest
{
    [TestClass]
    public class CabinetUnitTest
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
        [ExpectedException(typeof(NoBoxAvailableException), "No Box Available")]
        public void ShouldShowMessageGivenNoBoxAvailable()
        {
            var cabinet = new Cabinet(0);
            var bag = new Bag();
            cabinet.Store(bag);
        }

        [TestMethod]
        public void ShouldReturnTicketGivenBoxAvailableWhenStoreBag()
        {
            var cabinet = new Cabinet(1);
            var bag = new Bag();
            var ticket = cabinet.Store(bag);
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        [ExpectedException(typeof(NoBoxAvailableException), "No Box Available")]
        public void ShouldThrowExceptionWhenStoreMoreBagsThanCabinetCapacity()
        {
            var cabinet = new Cabinet(1);

            cabinet.Store(new Bag());
            cabinet.Store(new Bag());
        }

        [TestMethod]
        public void ShouldReturnDifferentTicketWhenStoreTwoBags()
        {
            var cabinet = new Cabinet(2);

            var bag1 = new Bag();
            var bag2 = new Bag();
            
            var ticket1 = cabinet.Store(bag1);
            var ticket2 = cabinet.Store(bag2);

            Assert.AreNotEqual(ticket1, ticket2);
        }

        [TestMethod]
        public void ShouldReturnBagWhenCorrectTicketPassedToCabinet()
        {
            var mybag = new Bag();

            var cabinet = new Cabinet(5);

            var myticket = cabinet.Store(mybag);

            var returnedBag = cabinet.Pick(myticket);

            Assert.AreEqual(mybag, returnedBag);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongTicketException), "Wrong Ticket")]
        public void ShouldGiveErrorMessageWhenUsedTicketPassedToCabinet()
        {
            var mybag = new Bag();

            var cabinet = new Cabinet(5);

            var myticket = cabinet.Store(mybag);

            cabinet.Pick(myticket);
            cabinet.Pick(myticket);

        }

    }
}
