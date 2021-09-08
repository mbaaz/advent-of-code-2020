using System;
using System.Collections.Generic;

namespace mbaaz.AdventOfCode2020.Day12.Models
{
    public static class PlacementExtensions
    {
        private static readonly Dictionary<Heading, Func<int, Position>> MoveMatrix = new() {
            { Heading.North, (value) => new Position( value, 0) },
            { Heading.South, (value) => new Position(-value, 0) },
            { Heading.West, (value) =>  new Position(0,  value) },
            { Heading.East, (value) =>  new Position(0, -value) }
        };

        public static Placement Move(this Placement placement, Heading heading, int value)
            => placement + MoveMatrix[heading](value);

        private static readonly Heading[] TurnLeftMatrix =  { Heading.North, Heading.West, Heading.South, Heading.East };
        private static readonly Heading[] TurnRightMatrix = { Heading.North, Heading.East, Heading.South, Heading.West };
        
        public static Placement Turn(this Placement initialPlacement, Direction direction, int degrees)
        {
            if(direction == Direction.Forward)
                throw new ApplicationException("How am I supposed to be able to _turn_ forward? Forward is subjective!");

            // Find the matrix where all directions come in a "turning to the [direction]" perspective
            var matrix = direction == Direction.Left ? TurnLeftMatrix : TurnRightMatrix;
            
            // Calculate how many steps we should turn
            var steps = degrees / 90;
            
            // Find our starting direction in the matrix supplied
            var startIndex = 0;
            while (initialPlacement.TurnedTowards != matrix[startIndex]) startIndex++;
            
            // Calculate a new direction by adding the steps we need to turn to the starting position, and then normalize the value to fit the matrix size
            var newDirection = matrix[(startIndex + steps) % matrix.Length];
            
            // Ta-daa! we have turned!
            return new Placement(newDirection, initialPlacement.Position);
        }
    }
}