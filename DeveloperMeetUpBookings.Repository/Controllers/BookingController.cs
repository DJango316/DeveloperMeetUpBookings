using DeveloperMeetUpBookings.NHibernate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperMeetUpBookings.Repository.Controllers
{
    public class BookingController : Controller
    {
        //private IBookingRepository _bookingRepository;

        //public BookingController(IBookingRepository bookingRepository)
        //{
        //    _bookingRepository = bookingRepository;
        //}

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
    }
}