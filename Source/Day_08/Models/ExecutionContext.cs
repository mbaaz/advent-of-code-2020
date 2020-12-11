namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public class ExecutionContext
    {
        public int CurrentLineNumber { get; set; }
        public int NextLineNumber { get; set; }
        public int Accumulator { get; set; }
        
        public ExecutionContext()
        {
            CurrentLineNumber = 0;
            NextLineNumber = 0;
            Accumulator = 0;
        }
    }
}