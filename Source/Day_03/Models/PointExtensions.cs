namespace mbaaz.AdventOfCode2020.Day03.Models
{
    public static class PointExtensions
    {
        public static Point MoveWithinGrid(this Point position, Point movement, Point gridSize)
        {
            return new Point((position.X + movement.X) % gridSize.X, (position.Y + movement.Y));
        }
    }
}