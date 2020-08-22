using DeveloperMeetUpBookings.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.NHibernate.Repositories
{
    public interface IBookingRepository
    {
        void InsertBooking(Booking booking);
    }
}