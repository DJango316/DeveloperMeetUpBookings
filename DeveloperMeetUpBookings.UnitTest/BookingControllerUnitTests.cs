using System;
using Autofac;
using DeveloperMeetUpBookings.Controllers;
using DeveloperMeetUpBookings.Queries.Models;
using DeveloperMeetUpBookings.Models;
using DeveloperMeetUpBookings.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DeveloperMeetUpBookings.UnitTest
{
    [TestClass]
    public class BookingControllerUnitTests
    {
        //Was not required in the end as I am using Moq to Mock the service but if I was to use DI this would be 
        //one way of setting it up.
        //[AssemblyInitialize()]
        //public static void MyTestInitialize()
        //{
        //    var builder = new ContainerBuilder();

        //    builder.RegisterType<IBookingService>().As<BookingService>().InstancePerRequest();

        //    // Set the dependency resolver to be Autofac.
        //    var container = builder.Build();
        //}

        Mock<IBookingService> bookingService;

        [TestInitialize]
        public void Setup()
        {
            bookingService = new Mock<IBookingService>();
        }

        [TestMethod]
        public void InsertNonExistingBooking()
        {
            var booking = new Models.Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "J10",
                MeetingWeek = "8"
            };

            var bookingQueryModel = new Queries.Models.Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "J10",
                MeetingWeek = "8"
            };

            var bookingRepositoryModel = new Repository.Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "J10",
                MeetingWeek = "8"
            };

            bookingService.Setup(check => check.CheckBookingExists(bookingQueryModel)).Returns(false);

            bookingService.Setup(insert => insert.InsertBooking(bookingRepositoryModel)).Returns(bookingRepositoryModel);

            var controller = new BookingController(bookingService.Object);
            
            var result = controller.CheckAndInsertIfBookingIsAvailable(booking);

            Assert.AreEqual(result.Name, booking.Name);
        }

        [TestMethod]
        public void InsertExistingBooking()
        {
            var booking = new Models.Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "A1",
                MeetingWeek = "1"
            };

            var bookingQueryModel = new Queries.Models.Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "A1",
                MeetingWeek = "1"
            };

            var bookingRepositoryModel = new Repository.Booking()
            {
                Name = "James Blackburn",
                Email = "james.r.b@hotmail.co.uk",
                Address = "108 Cranbourne Park",
                SeatId = "J10",
                MeetingWeek = "1"
            };

            //TODO Mock result is not being passed correctly still receiving 'false'
            bookingService.Setup(check => check.CheckBookingExists(bookingQueryModel)).Returns(true);

            bookingService.Setup(insert => insert.InsertBooking(bookingRepositoryModel)).Returns(bookingRepositoryModel);

            var controller = new BookingController(bookingService.Object);

            var result = controller.CheckAndInsertIfBookingIsAvailable(booking);

            Assert.IsNull(result);
        }
    }
}
