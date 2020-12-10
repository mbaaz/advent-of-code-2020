using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day07
{
    internal class ExtraTaskResultModel : IResult
    {
        public string Color { get; }
        public int BagCount { get; }

        public ExtraTaskResultModel(string color, int bagCount)
        {
            Color = color;
            BagCount = bagCount;
        }

        public override string ToString()
        {
            return $"Inside of a \"{Color}\" bag, {BagCount} other bags are required!";
        }
    }
}