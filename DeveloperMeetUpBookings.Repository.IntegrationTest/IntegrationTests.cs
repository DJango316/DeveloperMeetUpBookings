using System;
using System.Linq;
using DeveloperMeetUpBookings.Repository;
using DeveloperMeetUpBookings.Repository.IntegrationTest.Helpers;
using DeveloperMeetUpBookings.Repository.Repositories;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace DeveloperMeetUpBookings.Repository.IntegrationTest
{
    [TestClass]
    public class IntegrationTests
    {
        IBookingCRUDRepository _bookingRepository;
        ISession session;

        [TestInitialize]
        public void Setup()
        {
            session = NHibernateHelper.GetCurrentSession();
            _bookingRepository = new BookingCRUDRepository();
        }

        [TestMethod]
        public void TestInsertBooking()
        {
            var booking = new Booking()
            {
                Name = "test add",
                Email = "test@test.test",
                Address = "address test",
                SeatId = "J10",
                MeetingWeek = "6"
            };

            _bookingRepository.InsertBooking(booking);

            //TODO Query back results from test
            var query = session.QueryOver<Booking>().Where(x => x.Name == booking.Name).SingleOrDefault();

            Assert.IsNotNull(query);

            session.Delete(query);
            session.Flush();
        }
    }
}
