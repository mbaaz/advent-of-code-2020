using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day11
{
    internal class ResultModel : IResult
    {
        public int OccupiedSeats { get; }
        public int Simulations { get; }

        public ResultModel(int occupiedSeats, int simulations)
        {
            OccupiedSeats = occupiedSeats;
            Simulations = simulations;
        }

        public override string ToString()
            => $"There are {OccupiedSeats} occupied seats (after {Simulations} simulations)!";
    }
}