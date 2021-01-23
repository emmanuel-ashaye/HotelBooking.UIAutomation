using HotelBooking.UITests.Models;
using System.Collections.Generic;

namespace HotelBooking.UITests.Context
{
    internal class BookingContext
    {
        public List<Booking> Bookings { get; } = new List<Booking>();
    }
}
