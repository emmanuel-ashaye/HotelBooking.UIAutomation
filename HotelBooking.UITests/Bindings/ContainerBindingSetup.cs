using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using UIFramework.Dispatchers;
using UIFramework.Drivers;

namespace HotelBooking.UITests.Bindings
{
    [Binding]
    internal class ContainerSetupBindings
    {
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
            _container.RegisterTypeAs<UIWebDriver, ITestDriver>();
            _container.RegisterTypeAs<UIWebDispatcher, ITestFrameworkDispatcher>();
        }

        [AfterScenario]
        public void TesrDownContaienerBindings()
        {
            _container.Resolve<ITestDriver>().Dispose();
        }
    }
}