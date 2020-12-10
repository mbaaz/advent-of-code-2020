using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day07
{
    internal class BaseTaskResultModel : IResult
    {
        public string Color { get; }
        public int BagCount { get; }

        public BaseTaskResultModel(string color, int bagCount)
        {
            Color = color;
            BagCount = bagCount;
        }

        public override string ToString()
        {
            return $"Bag(s) that can contain (least) 1 \"{Color}\" bag: {BagCount}";
        }
    }
}