using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day12.Models;
using mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions;

namespace mbaaz.AdventOfCode2020.Day12
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 12;

        private readonly List<INavigationInstruction> _input;
        
        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        private static List<INavigationInstruction> ProcessInput(IEnumerable<string> input)
            => input.Select(NavigationInstruction.Parse).ToList();

        public IResult SolveBaseTask()
        {
            var initialPlacement = new Placement(Heading.East);
            var endPlacement = _input.Aggregate(initialPlacement, (curPlace, navInstr) => navInstr.NavigateFrom(curPlace));
            var manhattanDistance = endPlacement.Position.ManhattanDistanceTo(initialPlacement.Position);
            return new ResultModel(endPlacement, manhattanDistance);
        }

        public IResult SolveExtraTask()
        {
            throw new NotImplementedException();
            //return new ResultModel();
        }
    }
}