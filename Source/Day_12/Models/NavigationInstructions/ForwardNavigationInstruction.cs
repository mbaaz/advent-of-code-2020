namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public record ForwardNavigationInstruction : INavigationInstruction
    {
        public int Value { get; }

        public ForwardNavigationInstruction(int value)
        {
            Value = value;
        }
        
        public Placement NavigateFrom(Placement fromPlacement)
            => fromPlacement.Move(fromPlacement.TurnedTowards, Value);
    }
}