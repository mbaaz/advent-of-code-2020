namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public record AccumulatorInstruction : IInstruction
    {
        public const string OperationName = "acc";
        
        public int Argument { get; }

        public AccumulatorInstruction(int argument)
        {
            Argument = argument;
        }
        
        public void Execute(ExecutionContext context)
        {
            context.Accumulator += Argument;
        }
    }
}