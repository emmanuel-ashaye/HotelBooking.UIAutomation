using HotelBooking.UITests.Models;
using UIFramework.Dispatchers;
using UIFramework.Locators;

namespace HotelBooking.UITests.PageObjects
{
    public class HotelBookingPage
    {

        private readonly ITestFrameworkDispatcher _dispatcher;

        private readonly BookingTable _bookings;

        public HotelBookingPage(ITestFrameworkDispatcher dispatcher, BookingTable bookingTable)
        {
            _dispatcher = dispatcher;
            _bookings = bookingTable;
        }

        private FindBy FirstName => Find.ById("firstname");

        private FindBy LastName => Find.ById("lastname");

        private FindBy TotalPrice => Find.ById("totalprice");

        private FindBy DepositPaid => Find.ById("depositpaid");

        private FindBy Checkin => Find.ById("checkin");

        private FindBy Checkout => Find.ById("checkout");

        private FindBy SaveButton => Find.ByXPath("//input[@type='button' and @value=' Save ']");

        private FindBy Title => Find.ByXPath("//div[contains(@class, 'jumbotron') and contains(h1, 'Hotel booking form')]");

        public void EnterBookingDetails(Booking bookindDetails)
        {
            _dispatcher.EnterText(FirstName, bookindDetails.FirstName)
                .EnterText(LastName, bookindDetails.LastName)
                .EnterText(TotalPrice, bookindDetails.TotalPrice)
                .Select(DepositPaid, bookindDetails.DepositPaid)
                .EnterText(Checkin, bookindDetails.Checkin)
                .EnterText(Checkout, bookindDetails.Checkout);
        }

        public void ClickSave()
        {
            _dispatcher.Click(SaveButton);
        }

        public void VerifyPageTitle()
        {
            _dispatcher.WaitForElementToBeVisible(Title);
        }

        public void ClickDelete(Booking booking)
        {
            _bookings.DeleteRow(booking.FirstName, booking.LastName);
        }

        public void VerifyBookingAdded(Booking booking)
        {
            _bookings.VerifyRowIsAdded(booking.FirstName, booking.LastName);
        }

        public void VerifyBookingDeleted(Booking booking)
        {
            _bookings.VerifyRowIsDeleted(booking.FirstName, booking.LastName);
        }

    }
}
