﻿using mbaaz.AdventOfCode2020.Common;
using mbaaz.AdventOfCode2020.Common.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace mbaaz.AdventOfCode2020.Day11
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
