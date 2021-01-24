using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIFramework.Infrastructure
{
    public class Configuration
    {
        private static IConfiguration _configuration;

        static Configuration()
        {
            _configuration = GetConfiguration();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }

        public static string ApplicationBaseUrl => _configuration["ApplicationBaseUrl"];

        public static string RemoteDriverUrl => _configuration["RemoteDriverUrl"];
    }
}
