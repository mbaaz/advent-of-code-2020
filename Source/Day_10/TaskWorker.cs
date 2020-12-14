using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day10.Models;

namespace mbaaz.AdventOfCode2020.Day10
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 10;

        private readonly List<int> _input;
        
        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        private static List<int> ProcessInput(IEnumerable<string> input)
            => input.Select(int.Parse).ToList();
        
        public IResult SolveBaseTask()
        {
            var adapters = _input.OrderBy(item => item).ToList();
            var diffs = new[]{0, 0, 0, 1}; // The 1 represent the last difference (always 3) in the device itself
            var lastAdapter = 0;
            foreach (var adapter in adapters)
            {
                diffs[adapter - lastAdapter]++;
                lastAdapter = adapter;
            }
            return new ResultModel(diffs[1] * diffs[3]);
        }

        public IResult SolveExtraTask()
        {
            // Create a list of adapters ordered by jolts
            var adapters = _input.OrderBy(jolts => jolts).Select(jolts => new Adapter(jolts)).ToList();
            adapters.Insert(0, new Adapter(0)); // This is the outlet - need to start from the source
            
            // Loop through all adapters and add the next ones
            for (var i = 0; i < adapters.Count-1; i++)
            {
                for (var j = i+1; j < adapters.Count && j-i <= 3; j++)
                {
                    adapters[i].AddNextAdapter(adapters[j]);
                }
            }

            var paths = adapters[0].Weight; 
            return new ResultModel(paths);
        }
    }
}