namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record LeftNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public LeftNavigationInstruction(int value)
        {
            Value = value;
        }

        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Turn(Direction.Left, Value);
    }
}