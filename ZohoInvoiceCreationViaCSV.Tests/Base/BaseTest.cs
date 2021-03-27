using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using ZohoInvoiceRecordings.Models;

namespace ZohoInvoiceRecordings.Tests.Base
{
    public abstract class BaseTest
    {
        public ApplicationSettings applicationSettings { get; private set; }

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        public BaseTest()
        {
            var config = GetIConfigurationRoot(AppContext.BaseDirectory);

            applicationSettings = config.GetSection("ApplicationSettings").Get<ApplicationSettings>();
        }
    }
}
