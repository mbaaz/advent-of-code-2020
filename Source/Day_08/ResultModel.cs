using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day08
{
    internal class ResultModel : IResult
    {
        public int Accumulator { get; }

        public ResultModel(int accumulator)
        {
            Accumulator = accumulator;
        }

        public override string ToString()
            => $"The value of the Accumulator is {Accumulator}";
    }
}