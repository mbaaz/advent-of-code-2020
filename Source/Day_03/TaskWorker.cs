using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day03.Models;

namespace mbaaz.AdventOfCode2020.Day03
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 3;
        
        private readonly bool[][] _input;
        private readonly Point _gridSize;
        

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);

            _gridSize = new Point(_input[0].Length, _input.Length);
        }

        private static bool[][] ProcessInput(IEnumerable<string> input)
            => input.Select(line => line.Select(point => point == '#').ToArray()).ToArray();
        
        public IResult SolveBaseTask()
        {
            var start = new Point(0, 0);
            var slope = new Point(3, 1);
            var encounters = CountEncounters(start, slope, out var moves);
            return new BaseTaskResultModel(encounters, moves);
        }

        public IResult SolveExtraTask()
        {
            var start = new Point(0, 0);
            var slopes = new[]
            {
                new Point(1, 1),
                new Point(3, 1),
                new Point(5, 1),
                new Point(7, 1),
                new Point(1, 2),
            };

            var encounterProduct = slopes
                .Select(slope => CountEncounters(start, slope, out _))
                .ToArray()
            ;

            return new ExtraTaskResultModel(encounterProduct);
        }

        private int CountEncounters(Point start, Point slope, out int moves)
        {
            var encounters = 0;
            moves = 0;
            var position = start;
            while (position.Y < _gridSize.Y)
            {
                if (_input[position.Y][position.X])
                    encounters++;
                position = position.MoveWithinGrid(slope, _gridSize);
                moves++;
            }

            return encounters;
        }
    }
}

