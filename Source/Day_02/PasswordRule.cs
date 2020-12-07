namespace mbaaz.AdventOfCode2020.Day02
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