using System;
using System.Linq;
using DeveloperMeetUpBookings.NHibernate.Repositories;
using DeveloperMeetUpBookings.Repository.IntegrationTest.Helpers;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace DeveloperMeetUpBookings.Repository.IntegrationTest
{
    [TestClass]
    public class IntegrationTests
    {
        IBookingRepository _bookingRepository;
        ISession session;

        [TestInitialize]
        public void Setup()
        {
            session = NHibernateHelper.GetCurrentSession();
            _bookingRepository = new BookingRepository();
        }

        [TestMethod]
        public void TestInsertBooking()
        {
            var booking = new Booking()
            {
                Name = "test add",
                Email = "test@test.test",
                Address = "address test",
                SeatId = "J10"
            };

            _bookingRepository.InsertBooking(booking);

            var query = session.QueryOver<Booking>().Where(x => x.Name == booking.Name).SingleOrDefault();

            Assert.IsNotNull(query);
        }
    }
}
