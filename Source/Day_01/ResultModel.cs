using System.Linq;
using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day01
{
    internal class ResultModel : IResult
    {
        public int[] Numbers { get; }
        public int Result => Numbers.Aggregate(1, (mem, num) => mem * num);

        public ResultModel(params int[] numbers)
        {
            Numbers = numbers;
        }

        public override string ToString()
        {
            var numString = string.Join(", ", Numbers);
            return $"{Result} [{numString}]";
        }
    }
}