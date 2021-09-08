namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record NorthNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public NorthNavigationInstruction(int value)
        {
            Value = value;
        }

        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Move(Heading.North, Value);
    }
}