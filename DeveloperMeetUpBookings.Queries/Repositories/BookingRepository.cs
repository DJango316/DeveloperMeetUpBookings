﻿using DeveloperMeetUpBookings.Queries.Helpers;
using DeveloperMeetUpBookings.Queries.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Queries.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public Booking CheckIfBookingAvailable(Booking booking)
        {
            using (var db = NpocoHelpers.GetConnection())
            {
                // password has already been hashed elsewhere above in code
                var sql = Sql.Builder.Append(";exec dbo.[spCheckIfAvailable] @@Name = @0", booking.Name);
                sql.Append(", @@Email = @0", booking.Email);
                sql.Append(", @@Address = @0", booking.Address);
                sql.Append(", @@SeatId = @0", booking.SeatId);

                return db.Query<Booking>(sql).FirstOrDefault();
            }
        }
    }
}