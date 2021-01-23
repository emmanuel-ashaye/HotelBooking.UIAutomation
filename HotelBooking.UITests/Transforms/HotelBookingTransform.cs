using HotelBooking.UITests.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HotelBooking.UITests.Transforms
{
    [Binding]
    internal class HotelBookingTransform
    {
        [StepArgumentTransformation]
        public Booking SearchResponseAddressesTransform(Table table)
        {
            return table.CreateInstance<Booking>();
        }
    }
}
