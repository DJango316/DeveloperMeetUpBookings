using DeveloperMeetUpBookings.Queries.Helpers;
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
            var seats = booking.SeatId.Split(',');
            if(seats.Count() > 4)
            {
                return booking;
            }
            using (var db = NpocoHelpers.GetConnection())
            {
                var listOfNames = booking.Name.Split(',').ToList();
                var listOfEmails = booking.Email.Split(',').ToList();
                var listOfSeats = booking.SeatId.Split(',').ToList();

                var sql = new Sql();
                for(var i = 0; i < listOfNames.Count(); i++)
                {
                    //sql = Sql.Builder.Append(";exec dbo.[spCheckIfAvailable] @@Name like @0", "%" + listOfNames[i] + "%");
                    //sql.Append(", @@Email like @0", "%" + listOfEmails[i] + "%");
                    //sql.Append(", @@Address = @0", booking.Address);
                    //sql.Append(", @@SeatId like @0", "%" + listOfSeats[i] + "%");
                    //sql.Append(", @@MeetingWeek = @0", booking.MeetingWeek);

                    sql = Sql.Builder.Select("*").From("Booking").Where("Name like '%" + listOfNames[i] + "%' AND SeatId like '%" + listOfSeats[i] + "%' AND MeetingWeek = " + booking.MeetingWeek);

                    var results = db.Query<Booking>(sql);
                    var resultList = results.ToList();

                    if (listOfNames.Count() > 1 && resultList.Count() > 0)
                    {
                        var listOfResultNames = new List<string>();
                        var listOfResultSeats = new List<string>();
                        foreach (var result in resultList)
                        {
                            listOfResultNames.AddRange(result.Name.Split(','));
                            listOfResultSeats.AddRange(result.SeatId.Split(','));
                        }
                        
                        if (listOfResultNames.Contains(listOfNames[i]))
                        {
                            var nameResultIndex = listOfResultNames.IndexOf(listOfNames[i]);
                            var developersResultSeat = listOfResultSeats[nameResultIndex];

                            var nameIndex = listOfNames.IndexOf(listOfNames[i]);
                            var developersSeat = listOfSeats[nameIndex];

                            if(developersResultSeat == developersSeat)
                            {
                                return db.Query<Booking>(sql).FirstOrDefault();
                            }
                        }
                    }
                }

                return db.Query<Booking>(sql).FirstOrDefault();
            }
        }
    }
}