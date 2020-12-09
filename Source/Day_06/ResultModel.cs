using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day06
{
    internal class ResultModel : IResult
    {
        public int Sum { get; }

        public ResultModel(int sum)
        {
            Sum = sum;
        }

        public override string ToString()
        {
            return $"Sum of all group-answers: {Sum}";
        }
    }
}