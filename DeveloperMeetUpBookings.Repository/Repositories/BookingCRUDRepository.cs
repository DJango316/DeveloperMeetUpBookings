using DeveloperMeetUpBookings.Repository;
using DeveloperMeetUpBookings.Repository.Helpers;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Repository.Repositories
{
    public class BookingCRUDRepository : IBookingCRUDRepository
    {
        public Booking InsertBooking(Booking booking)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction trans = session.BeginTransaction();
            var result = session.CreateSQLQuery("exec spInsertBooking :pName, :pEmail, :pAddress, :pSeatId")
                .AddEntity(typeof(Booking))
                    .SetParameter("pName", booking.Name)
                    .SetParameter("pEmail", booking.Email)
                    .SetParameter("pAddress", booking.Address)
                    .SetParameter("pSeatId", booking.SeatId)
                    .List<Booking>();

           // trans.Commit();

            session.SaveOrUpdate(booking);

            return booking;
        }
    }
}