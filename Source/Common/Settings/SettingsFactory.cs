using Microsoft.Extensions.Configuration;

namespace mbaaz.AdventOfCode2020.Common.Settings
{
    public class SettingsFactory
    {
        private readonly IConfiguration _configuration;

        public SettingsFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TSettings CreateSettings<TSettings>()
            where TSettings : class, ISettings, new()
        {
            var settings = new TSettings();
            _configuration.GetSection(settings.SectionName).Bind(settings);
            return settings;
        }
    }
}