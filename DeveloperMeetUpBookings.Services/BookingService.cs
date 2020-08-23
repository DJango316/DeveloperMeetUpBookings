using DeveloperMeetUpBookings.Queries.Models;
using DeveloperMeetUpBookings.Queries.Repositories;
using DeveloperMeetUpBookings.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Services
{
    public class BookingService : IBookingService
    {
        IBookingRepository _bookingRepository;
        IBookingCRUDRepository _bookingCRUDRepository;

        public BookingService(IBookingRepository bookingRepository, IBookingCRUDRepository bookingCRUDRepository)
        {
            _bookingRepository = bookingRepository;
            _bookingCRUDRepository = bookingCRUDRepository;
        }

        public bool CheckBookingExists(Booking booking)
        {
            var result = _bookingRepository.CheckIfBookingAvailable(booking);

            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Repository.Booking InsertBooking(Repository.Booking booking)
        {
            var bookingRecord = _bookingCRUDRepository.InsertBooking(booking);

            return bookingRecord;
        }
    }
}