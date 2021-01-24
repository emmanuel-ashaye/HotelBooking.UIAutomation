using HotelBooking.UITests.Context;
using HotelBooking.UITests.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HotelBooking.UITests.Transforms
{
    [Binding]
    internal class HotelBookingTransform
    {
        private readonly BookingContext _bookingContext;

        public HotelBookingTransform(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        [StepArgumentTransformation]
        public Booking SearchResponseAddressesTransform(Table table)
        {
            var booking = table.CreateInstance<Booking>();
            _bookingContext.Bookings.Add(booking);
            return booking;
        }
    }
}
