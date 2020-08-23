using DeveloperMeetUpBookings.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Services
{
    public interface IBookingService
    {
        bool CheckBookingIsAvailable(Booking booking);

        Repository.Booking InsertBooking(Repository.Booking booking);
    }
}