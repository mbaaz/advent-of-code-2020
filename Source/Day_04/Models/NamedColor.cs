namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public record NamedColor : IColor
    {
        public ColorName Name { get; }

        public NamedColor(ColorName name)
        {
            Name = name;
        }
    }
}