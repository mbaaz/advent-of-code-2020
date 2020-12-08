namespace mbaaz.AdventOfCode2020.Day03.Models
{
    public record Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}