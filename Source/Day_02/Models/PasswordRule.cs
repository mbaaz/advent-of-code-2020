using mbaaz.AdventOfCode2020.Common.Models;

namespace mbaaz.AdventOfCode2020.Day02.Models
{
    public record PasswordRule 
    {
        public char Sequence { get; }
        public Range<int> Occurences { get; }

        public PasswordRule(char sequence, Range<int> occurences)
        {
            Sequence = sequence;
            Occurences = occurences;
        }
    }
}