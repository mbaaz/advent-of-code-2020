using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day12.Models;

namespace mbaaz.AdventOfCode2020.Day12
{
    internal class ResultModel : IResult
    {
        public Placement Placement { get; }
        public int ManhattanDistance { get; }

        public ResultModel(Placement placement, int manhattanDistance)
        {
            Placement = placement;
            ManhattanDistance = manhattanDistance;
        }

        public override string ToString()
            => $"Your placement is: \"{Placement}\" with a Manhattan Distance of {ManhattanDistance}.";
    }
}