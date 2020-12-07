using mbaaz.AdventOfCode2020.Common.Configuration;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mbaaz.AdventOfCode2020.Common
{
    internal sealed class Startup
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ConfigurationFactory>()
                .AddTransient<SettingsFactory>()
                .AddSingleton<Printer>()

                .AddSingleton<IConfiguration>(svcProvider => svcProvider.GetService<ConfigurationFactory>()?.CreateConfiguration())
                .AddSingleton<Settings.Settings>(svcProvider => svcProvider.GetService<SettingsFactory>()?.CreateSettings<Settings.Settings>())

                .AddTransient<AoCRunner>()
            ;
        }
    }
}