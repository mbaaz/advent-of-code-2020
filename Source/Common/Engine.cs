using System;
using mbaaz.AdventOfCode2020.Common.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace mbaaz.AdventOfCode2020.Common
{
    public static class Engine
    {
        private static IServiceCollection _serviceCollection;
        public static IServiceCollection ServiceCollection
        {
            get
            {
                _services = null; // reset the Service Provider, so these changes will take effect!
                return _serviceCollection ??= CreateServiceCollection();
            }
        }

        private static IServiceProvider _services;
        public static IServiceProvider Services => _services ??= LoadServices();

        private static IServiceCollection CreateServiceCollection()
        {
            var serviceCollection = new ServiceCollection();
            
            // Run registration
            var startup = new Startup();
            startup.RegisterServices(serviceCollection);

            return serviceCollection;
        }

        private static IServiceProvider LoadServices()
        {
            var services = ServiceCollection.BuildServiceProvider();
            return services;
        }

        public static void Run()
        {
            var runner = Services.GetService<AoCRunner>();

            if (runner == null)
            {
                Console.WriteLine("ERROR: No IWorker registered!");
                return;
            }

            runner.Run();
        }
    }
}