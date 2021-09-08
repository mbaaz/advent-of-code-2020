namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record WestNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public WestNavigationInstruction(int value)
        {
            Value = value;
        }
        
        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Move(Heading.West, Value);
    }
}