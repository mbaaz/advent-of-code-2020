using System;

namespace mbaaz.AdventOfCode2020.Day12.Models
{
    public record Placement
    {
        public Heading TurnedTowards { get; }
        public Position Position { get; }
        
        public Placement(Heading turnedTowards)
            : this(turnedTowards, new Position())
        {
        }
        
        public Placement(Heading turnedTowards, Position position)
        {
            TurnedTowards = turnedTowards;
            Position = position;
        }

        public override string ToString()
        {
            var facing = TurnedTowards.ToString().ToLower();
            
            return $"{Position} (facing {facing})";
        }

        public static Placement operator +(Placement placement, Position position)
        {
            if (placement == null)
                throw new ArgumentNullException(nameof(placement));
            
            if (position == null)
                throw new ArgumentNullException(nameof(position));

            return new Placement(placement.TurnedTowards, placement.Position + position);
        }
        
        public static Placement operator +(Placement placement, (int North, int West) position)
        {
            if (placement == null)
                throw new ArgumentNullException(nameof(position));
            
            return new Placement(placement.TurnedTowards, placement.Position + position);
        }
    }
}