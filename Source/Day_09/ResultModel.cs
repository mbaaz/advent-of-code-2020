using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day09
{
    internal class ResultModel : IResult
    {
        public long Number { get; }

        public ResultModel(long number)
        {
            Number = number;
        }

        public override string ToString()
            => $"The number you are looking for is: {Number}";
    }
}