namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public record NoOperationInstruction : IInstruction
    {
        public const string OperationName = "nop";
        
        public int Argument { get; }

        public NoOperationInstruction(int argument)
        {
            Argument = argument;
        }

        public void Execute(ExecutionContext context)
        {
            // NO OPERATION! (it's in the name!)
        }
    }
}