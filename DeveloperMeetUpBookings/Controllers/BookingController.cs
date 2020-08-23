using DeveloperMeetUpBookings.Queries.Models;
using DeveloperMeetUpBookings.Repository;
using DeveloperMeetUpBookings.Services;
using DeveloperMeetUpBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DeveloperMeetUpBookings.Controllers
{
    public class BookingController : Controller
    {
        public IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public Models.Booking CheckAndInsertIfBookingIsAvailable(Models.Booking booking)
        {
            var queryBookingModel = new Queries.Models.Booking()
            {
                Name = booking.Name,
                Email = booking.Email,
                Address = booking.Address,
                SeatId = booking.SeatId,
                MeetingWeek = booking.MeetingWeek
            };

            var result = _bookingService.CheckBookingExists(queryBookingModel);

            if(result == false)
            {
                var insertedBookingModel = new Repository.Booking()
                {
                    Name = queryBookingModel.Name,
                    Email = queryBookingModel.Email,
                    Address = queryBookingModel.Address,
                    SeatId = queryBookingModel.SeatId,
                    MeetingWeek = queryBookingModel.MeetingWeek
                };

                var insertBooking = _bookingService.InsertBooking(insertedBookingModel);

                return booking;
            }
            else
            {
                //More than 4 seats or Booking already exists for seat!
                return null;
            }
        }
    }
}