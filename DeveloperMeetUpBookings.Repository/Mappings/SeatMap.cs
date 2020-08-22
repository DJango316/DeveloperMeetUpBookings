using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Repository.Mappings
{
    public class SeatMap : ClassMap<Seat>
    {
        public SeatMap()
        {
            Id(x => x.SeatId).GeneratedBy.Native();
            Map(x => x.Label);
        }
    }
}