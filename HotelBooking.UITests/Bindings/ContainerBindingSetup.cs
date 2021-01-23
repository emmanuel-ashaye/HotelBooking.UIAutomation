using BoDi;
using HotelBooking.UITests.PageObjects;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using UIFramework.Dispatchers;
using UIFramework.Drivers;

namespace HotelBooking.UITests.Bindings
{
    [Binding]
    public class ContainerSetupBindings
    {

        private string _baseUrl;

        private readonly IConfiguration _configuration;

        private readonly IObjectContainer _container;

        public ContainerSetupBindings(IObjectContainer container)
        {
            _container = container;
            _configuration = GetConfiguration();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }

        [BeforeScenario]
        public void SetupContaienerBindings()
        {
            _baseUrl = _configuration["ApplicationBaseUrl"];

            ITestDriver _driver = new UIWebDriver(_baseUrl);
            _container.RegisterInstanceAs(_driver);

            ITestFrameworkDispatcher _dispatcher = new UIWebDispatcher(_driver as UIWebDriver);
            _container.RegisterInstanceAs(_dispatcher);

            HotelBookingPage hotelBookingPage = new HotelBookingPage(_dispatcher);
            _container.RegisterInstanceAs(hotelBookingPage);
        }


        [AfterScenario]
        public void TesrDownContaienerBindings()
        {
            _container.Resolve<ITestDriver>().Dispose();
        }
    }
}