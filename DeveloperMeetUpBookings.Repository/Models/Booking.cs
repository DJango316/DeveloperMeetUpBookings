using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Repository
{
    public class Booking
    {
        public virtual int BookingId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual string SeatId { get; set; }
    }
}