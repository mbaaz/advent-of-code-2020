namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record RightNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public RightNavigationInstruction(int value)
        {
            Value = value;
        }

        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Turn(Direction.Right, Value);
    }
}