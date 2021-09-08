using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day17
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 17;

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
            throw new NotImplementedException();
            //return new ResultModel();
        }

        public IResult SolveExtraTask()
        {
            throw new NotImplementedException();
            //return new ResultModel();
        }
    }
}