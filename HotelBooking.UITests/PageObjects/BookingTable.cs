using System.Text;
using UIFramework.Dispatchers;
using UIFramework.Locators;

namespace HotelBooking.UITests.PageObjects
{
    public class BookingTable
    {

        private readonly ITestFrameworkDispatcher _dispatcher;

        public BookingTable(ITestFrameworkDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void VerifyRowIsAdded(params string[] rowValues)
        {
            _dispatcher.WaitForElementToBeVisible(FindRow(rowValues));
        }
        public void VerifyRowIsDeleted(params string[] rowValues)
        {
            _dispatcher.WaitForNoElement(FindRow(rowValues));
        }

        public void DeleteRow(params string[] rowValues)
        {
            _dispatcher.Click(DeleteButton(rowValues));
        }

        private static FindBy Id => Find.ByXPath("//div[@id='bookings']");

        private static FindBy DeleteButton(params string[] rowValues)
        {
            return Find.ByXPath($"{FindRow(rowValues)}//input[@value='Delete']");
        }

        private static FindBy Cell(string value)
        {
            return Find.ByXPath($"div[child::p[text()='{value}']]");
        }

        private static FindBy Rows()
        {
            return Find.ByXPath($"{Id}//div[contains(@class, 'row')]");
        }

        private static FindBy FindRow(params string[] rowValues)
        {
            string rowsLocator = Rows().Locator;
            StringBuilder rowLocator = new StringBuilder(rowsLocator).Remove(rowsLocator.Length - 1, 1);

            foreach (var value in rowValues)
            {
                rowLocator.Append($"and child::{Cell(value)}");
            }

            rowLocator.Append("]");

            return Find.ByXPath(rowLocator.ToString());
        }
    }
}
