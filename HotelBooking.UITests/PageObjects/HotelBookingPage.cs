using HotelBooking.UITests.Models;
using UIFramework.Dispatchers;
using UIFramework.Locators;

namespace HotelBooking.UITests.PageObjects
{
    internal class HotelBookingPage
    {

        private readonly ITestFrameworkDispatcher _dispatcher;

        public HotelBookingPage(ITestFrameworkDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public FindBy FirstName => Find.ById("firstname");

        public FindBy LastName => Find.ById("lastname");

        public FindBy TotalPrice => Find.ById("totalprice");

        public FindBy DepositPaid => Find.ById("depositpaid");

        public FindBy Checkin => Find.ById("checkin");

        public FindBy Checkout => Find.ById("checkout");

        public FindBy SaveButton => Find.ByXPath("//input[@type='button' and @value=' Save ']");

        public FindBy Title => Find.ByXPath("//div[contains(@class, 'jumbotron') and contains(h1, 'Hotel booking form')]");

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

        public void ClickDelete(Booking booking)
        {
            _dispatcher.Click(Table.DeleteButton(booking.FirstName, booking.LastName));
        }

        internal void VerifyBookingDeleted(Booking booking)
        {
            _dispatcher.WaitForNoElement(Table.DeleteButton(booking.FirstName, booking.LastName));
        }

        internal void VerifyBookingAdded(Booking booking)
        {
            _dispatcher.WaitForElementToBeVisible(Table.Row(booking.FirstName, booking.LastName));
        }

        internal void VerifyPageTitle()
        {
            _dispatcher.WaitForElementToBeVisible(Title);
        }
    }
}
