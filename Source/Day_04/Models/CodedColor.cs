namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public record CodedColor : IColor
    {
        public string Code { get; }

        public CodedColor(string code)
        {
            Code = code;
        }
    }
}