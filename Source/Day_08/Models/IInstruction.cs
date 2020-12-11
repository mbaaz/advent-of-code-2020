namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public interface IInstruction
    {
        int Argument { get; }

        void Execute(ExecutionContext context);
    }
}