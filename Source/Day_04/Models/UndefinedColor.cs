namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public record UndefinedColor : IColor
    {
        public string Color { get; }

        public UndefinedColor(string color)
        {
            Color = color;
        }
    }
}