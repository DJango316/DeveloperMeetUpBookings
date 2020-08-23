using DeveloperMeetUpBookings.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Repository.Repositories
{
    public interface IBookingCRUDRepository
    {
        Booking InsertBooking(Booking booking);
    }
}