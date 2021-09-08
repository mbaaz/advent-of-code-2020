namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record SouthNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public SouthNavigationInstruction(int value)
        {
            Value = value;
        }
        
        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Move(Heading.South, Value);
    }
}