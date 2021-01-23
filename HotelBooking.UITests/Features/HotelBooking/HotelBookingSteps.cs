using HotelBooking.UITests.Context;
using HotelBooking.UITests.Models;
using HotelBooking.UITests.PageObjects;
using System.Linq;
using TechTalk.SpecFlow;

namespace HotelBooking.UITests.Features
{
    [Binding]
    [Scope(Feature = "AddHotelBooking")]
    [Scope(Feature = "DeleteHotelBooking")]
    internal sealed class HotelBookingSteps
    {
        private readonly BookingContext _bookingContext;
        private readonly HotelBookingPage _hotelBookingPage;

        public HotelBookingSteps(BookingContext bookingContext, HotelBookingPage hotelBookingpage)
        {
            _bookingContext = bookingContext;
            _hotelBookingPage = hotelBookingpage;
        }

        [Given(@"I visit the Hotel booking form")]
        public void GivenIVisitHotelBookingForm()
        {
            _hotelBookingPage.VerifyPageTitle();
        }

        [StepDefinition(@"I enter these booking details")]
        public void IEnterTheseDetails(Booking booking)
        {
            _hotelBookingPage.EnterBookingDetails(booking);
            _bookingContext.Bookings.Add(booking);
        }

        [When(@"I click the save button")]
        public void WhenTheSaveButtonIsClicked()
        {
            _hotelBookingPage.ClickSave();
        }

        [When(@"I click the delete button against my booking")]
        public void WhenTheDeleteButtonIsClicked()
        {
            var booking = _bookingContext.Bookings.FirstOrDefault();
            _hotelBookingPage.ClickDelete(booking);
        }

        [StepDefinition(@"I have a Hotel booking")]
        public void IHaveAddedAHotelBooking(Booking booking)
        {
            IEnterTheseDetails(booking);
            WhenTheSaveButtonIsClicked();
        }

        [Then(@"a new hotel booking is added")]
        public void ThenNewHotelBookingIsAdded()
        {
            var booking = _bookingContext.Bookings.FirstOrDefault();
            _hotelBookingPage.VerifyBookingAdded(booking);

        }

        [Then("my hotel booking is removed")]
        public void ExistingHotelBookingIsRemoved()
        {
            var booking = _bookingContext.Bookings.FirstOrDefault();
            _hotelBookingPage.VerifyBookingDeleted(booking);
            _bookingContext.Bookings.Remove(booking);
        }
    }
}
