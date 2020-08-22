﻿using DeveloperMeetUpBookings.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Queries.Repositories
{
    public interface IBookingRepository
    {
        Booking CheckIfBookingAvailable(Booking booking);
    }
}