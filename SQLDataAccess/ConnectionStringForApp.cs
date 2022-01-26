using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SQLDataAccess
{
    public class ConnectionStringForApp
    {
        private readonly String ApplicationName;
        public ConnectionStringForApp(string applicationName)
        {
            ApplicationName = applicationName;
        }

        public string Value()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString(ApplicationName);
        }
    }
}
