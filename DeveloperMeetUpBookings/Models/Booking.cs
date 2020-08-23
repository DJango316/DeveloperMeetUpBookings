using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string SeatId { get; set; }

        public string MeetingWeek { get; set; }
    }
}