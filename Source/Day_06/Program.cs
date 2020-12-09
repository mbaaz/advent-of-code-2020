using System;
using System.Linq;
using mbaaz.AdventOfCode2020.Common;
using mbaaz.AdventOfCode2020.Common.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace mbaaz.AdventOfCode2020.Day06
{
    internal class Program
    {
        private static void Main()
        {
            Engine.ServiceCollection.AddTransient<IWorker, TaskWorker>();
            Engine.Run();
        }
    }
}
