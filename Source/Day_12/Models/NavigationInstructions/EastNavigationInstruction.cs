namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record EastNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public EastNavigationInstruction(int value)
        {
            Value = value;
        }
        
        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Move(Heading.East, Value);
    }
}