using DeveloperMeetUpBookings.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperMeetUpBookings.Repository.Controllers
{
    public class SeatController : Controller
    {
        //private ISeatRepository _seatRepository;

        //public SeatController(ISeatRepository seatRepository)
        //{
        //    _seatRepository = seatRepository;
        //}

        // GET: Seat
        public ActionResult Index()
        {
            return View();
        }
    }
}