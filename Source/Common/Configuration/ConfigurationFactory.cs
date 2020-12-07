using Microsoft.Extensions.Configuration;

namespace mbaaz.AdventOfCode2020.Common.Configuration
{
    public class ConfigurationFactory
    {
        public const string CONFIG_FILE_NAME = "appsettings.json";

        public IConfiguration CreateConfiguration()
        {
            var builder = new ConfigurationBuilder();

            // Read from JSON file
            builder.AddJsonFile(CONFIG_FILE_NAME);

            // Add User Secrets (for SessionID)
            builder.AddUserSecrets<ConfigurationFactory>();

            // Build and return
            var configuration = builder.Build();
            return configuration;
        }
    }
}