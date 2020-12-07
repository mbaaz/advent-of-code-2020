using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day03
{
    internal class BaseTaskResultModel : IResult
    {
        public int Encounters { get; }
        public int Moves { get; }

        public BaseTaskResultModel(int encounters, int moves)
        {
            Encounters = encounters;
            Moves = moves;
        }

        public override string ToString()
        {
            return $"{Encounters} tree(s) encountered! [{Moves} moves was made!].";
        }
    }
}