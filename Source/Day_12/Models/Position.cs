using System;

namespace mbaaz.AdventOfCode2020.Day12.Models
{
    public record Position
    {
        public int North { get; }
        public int West { get; }

        public Position()
        {
            North = 0;
            West = 0;
        }
        
        public Position(int north, int west)
        {
            North = north;
            West = west;
        }
        
        public override string ToString()
        {
            var northSouth = (North >= 0 ? Heading.North : Heading.South).ToString().ToLower();
            var northSouthValue = Math.Abs(North);
            
            var westEast = (West >= 0 ? Heading.West : Heading.East).ToString().ToLower();
            var westEastValue = Math.Abs(West);
            
            return $"{westEast} {westEastValue}, {northSouth} {northSouthValue}";
        }

        public static Position operator +(Position fromPosition, Position relativeAddition)
        {
            return new Position(
                north: fromPosition.North + relativeAddition.North,
                west:  fromPosition.West  + relativeAddition.West
            );
        }
        
        public static Position operator +(Position fromPosition, (int North, int West) relativeAddition)
        {
            return new Position(
                north: fromPosition.North + relativeAddition.North,
                west:  fromPosition.West  + relativeAddition.West
            );
        }
    }

    public static class PositionExtensions
    {
        public static int ManhattanDistanceTo(this Position from, Position to)
            => Math.Abs(from.North - to.North) + Math.Abs(from.West - to.West);
    }
}