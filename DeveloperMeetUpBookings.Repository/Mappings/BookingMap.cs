using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Repository.Mappings
{
    public class BookingMap : ClassMap<Booking>
    {
        public BookingMap()
        {
            Table("Booking");
            Id(x => x.BookingId).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Address);
            Map(x => x.SeatId);
            Map(x => x.MeetingWeek);
        }
    }
}