using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Repository
{
    public class Seat
    {
        public virtual int SeatId { get; set; }

        public virtual string Label { get; set; }
    }
}