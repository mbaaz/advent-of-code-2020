namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public record JumpInstruction : IInstruction
    {
        public const string OperationName = "jmp";
        
        public int Argument { get; }

        public JumpInstruction(int argument)
        {
            Argument = argument;
        }

        public void Execute(ExecutionContext context)
        {
            context.NextLineNumber = context.CurrentLineNumber + Argument;
        }
    }
}