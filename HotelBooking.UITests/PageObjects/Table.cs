using UIFramework.Locators;

namespace HotelBooking.UITests.PageObjects
{
    class Table
    {
        public static FindBy Id => Find.ByXPath("//div[@id='bookings']");

        public static FindBy DeleteButton(string firstName, string lastName)
        {
            //return Find.ByXPath($"//div[p='{firstName}']//following-sibling::div[p='{lastName}']//following-sibling::div/input[@value='Delete']");
            return Find.ByXPath($"{Id.Locator}/div[descendant::text()='{firstName}' and descendant::text()='{lastName}']//input[@value='Delete']");
        }

        internal static FindBy Row(string firstName, string lastName)
        {
            return Find.ByXPath($"{Id.Locator}/div[descendant::text()='{firstName}' and descendant::text()='{lastName}']");
        }
    }
}
