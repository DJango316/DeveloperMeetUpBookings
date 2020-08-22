using System;
using DeveloperMeetUpBookings.Queries.Helpers;
using DeveloperMeetUpBookings.Queries.Models;
using DeveloperMeetUpBookings.Queries.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperMeetUpBookings.Query.IntegrationTest
{
    [TestClass]
    public class QueryBookingIntegrationTests
    {
        IBookingRepository _bookingRepository;

        [TestInitialize]
        public void Setup()
        {
            _bookingRepository = new BookingRepository();
        }


        [TestMethod]
        public void CheckForExistingBooking()
        {
            var booking = new Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "A1"
            };

            var result = _bookingRepository.CheckIfBookingAvailable(booking);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckForNonExistingBooking()
        {
            var booking = new Booking()
            {
                Name = "Jame Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "A1"
            };

            var result = _bookingRepository.CheckIfBookingAvailable(booking);

            Assert.IsNull(result);
        }
    }
}
