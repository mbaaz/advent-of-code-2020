using mbaaz.AdventOfCode2020.Day08.Models;

namespace mbaaz.AdventOfCode2020.Day08.Exceptions
{
    public class InfiniteLoopExecutionException : ExecutionException
    {
        private const string ERROR_MESSAGE = "Infinite Loop detected - HALTED!";
        
        public InfiniteLoopExecutionException(ExecutionContext context)
            : base(context, ERROR_MESSAGE)
        {
        }
    }
}