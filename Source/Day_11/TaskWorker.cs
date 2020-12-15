using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day11.Models;

namespace mbaaz.AdventOfCode2020.Day11
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 11;

        private readonly Room _input;
        
        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        private static Room ProcessInput(IEnumerable<string> input)
            => new Room(input.Select(row => row.Select(token => token.ToSpaceType()).ToArray()).ToArray().To2D());
        
        public IResult SolveBaseTask()
        {
            var room = _input;
            var simulations = 0;
            var simulateMovement = true;
            while (simulateMovement)
            {
                simulations++;
                room = room.SimulateMovement(occupiedAdjacentSeatsToVacateLimit: 4, seatPolicy: AdjacentSeatPolicy.OnlyImmediateNeighbors, out var changesMade);
                simulateMovement = changesMade > 0;
            }

            return new ResultModel(room.OccupiedSeats, simulations);
        }

        public IResult SolveExtraTask()
        {
            var room = _input;
            var simulations = 0;
            var simulateMovement = true;
            while (simulateMovement)
            {
                simulations++;
                room = room.SimulateMovement(occupiedAdjacentSeatsToVacateLimit: 5, seatPolicy: AdjacentSeatPolicy.NearestVisibleSeat, out var changesMade);
                simulateMovement = changesMade > 0;
            }

            return new ResultModel(room.OccupiedSeats, simulations);
        }
    }
}