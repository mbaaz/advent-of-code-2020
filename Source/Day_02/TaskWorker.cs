using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day02.Models;

namespace mbaaz.AdventOfCode2020.Day02
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 2;

        private readonly List<PasswordRecord> _input;


        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        private static List<PasswordRecord> ProcessInput(IEnumerable<string> input)
            => input.Select(line => line.ParseAsPasswordRecord()).ToList();

        public IResult SolveBaseTask()
        {
            var totalCount = _input.Count;
            var validCount = _input.Count(record => record.IsValidAccordingToFirstTaskRules());
            
            return new ResultModel(validCount, totalCount);
        }

        public IResult SolveExtraTask()
        {
            var totalCount = _input.Count;
            var validCount = _input.Count(record => record.IsValidAccordingToSecondTaskRules());
            
            return new ResultModel(validCount, totalCount);
        }
    }
}