using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day04
{
    internal class ResultModel : IResult
    {
        public int ValidPassports { get; }
        public int TotalPassports { get; }

        public ResultModel(int validPassports, int totalPassports)
        {
            ValidPassports = validPassports;
            TotalPassports = totalPassports;
        }

        public override string ToString()
        {
            return $"{ValidPassports} are valid [of {TotalPassports} in total].";
        }
    }
}