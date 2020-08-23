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

            ////Can use a stored procedure via NHibernate but I have decided to pass the NHibernate mapping model through 
            ////to NHibernates ISession so I can use SaveOrUpdate. I think this way is more readable also. I am keeping the 
            ////code commented out here to show how it would be done using the insert stored procedure.
            //var result = session.CreateSQLQuery("exec spInsertBooking :pName, :pEmail, :pAddress, :pSeatId")
            //    .AddEntity(typeof(Booking))
            //        .SetParameter("pName", booking.Name)
            //        .SetParameter("pEmail", booking.Email)
            //        .SetParameter("pAddress", booking.Address)
            //        .SetParameter("pSeatId", booking.SeatId)
            //        .List<Booking>();

            session.SaveOrUpdate(booking);

            trans.Commit();

            return booking;
        }
    }
}