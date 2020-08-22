using System;
using System.Collections.Generic;
using System.Linq;
using DeveloperMeetUpBookings.NHibernate.Repositories;
using DeveloperMeetUpBookings.Repository.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;

namespace DeveloperMeetUpBookings.Repository.UnitTest
{
    [TestClass]
    public class BookingRepositoryUnitTests
    {
        Mock<ISession> sessionMock;
        Mock<ITransaction> transactionMock;
        Mock<IQuery> queryMock;

        [TestInitialize]
        public void Setup()
        {
            sessionMock = new Mock<ISession>();
            transactionMock = new Mock<ITransaction>();
            queryMock = new Mock<IQuery>();
            sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
        }

        [TestMethod]
        public void InsertBookingTest()
        {
            var booking = new List<Booking>()
            {   new Booking()
                {
                    Name = "test add",
                    Email = "test@test.test",
                    Address = "address test",
                    SeatId = "J10"
                }
            };

            sessionMock.Setup(s => s.Query<Booking>()).Returns(booking.AsQueryable());
            var query = sessionMock.Object.Query<Booking>();

            var result = query.Where(x => x.Name != "").ToList();

            Assert.IsNotNull(result);
        }
    }
}
