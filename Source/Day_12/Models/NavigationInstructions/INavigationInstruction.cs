namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public interface INavigationInstruction
    {
        int Value { get;  }

        Placement NavigateFrom(Placement fromPlacement);
    }
}