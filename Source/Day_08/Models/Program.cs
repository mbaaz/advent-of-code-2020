using System;
using System.Collections.Generic;
using mbaaz.AdventOfCode2020.Day08.Exceptions;

namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public class Program
    {
        private readonly IInstruction[] _instructions;
        private readonly List<int> _executionHistory;
        
        public Program(IInstruction[] instructions)
        {
            _instructions = instructions;
            _executionHistory = new List<int>();
        }

        public ExecutionContext Execute()
        {
            var context = new ExecutionContext();

            while(true)
            {
                // Advance the context location indicators
                context.CurrentLineNumber = context.NextLineNumber;
                context.NextLineNumber += 1;

                // Trying to execute the next line outside of instruction space will terminate OK
                if (context.CurrentLineNumber == _instructions.Length)
                    return context;
                
                // Trying to execute a line way outside of instruction scope will not be permitted!
                if(context.CurrentLineNumber > _instructions.Length)
                    throw new ExecutionException(context, $"Instruction at place {context.CurrentLineNumber} is not available!");
                
                // Check history for previous executions
                if (_executionHistory.Contains(context.CurrentLineNumber))
                    throw new InfiniteLoopExecutionException(context);
                
                // Add this to history
                _executionHistory.Add(context.CurrentLineNumber);

                // Fetch current instruction to execute
                var instruction = _instructions[context.CurrentLineNumber];

                // Execute the instruction
                instruction.Execute(context);
            }
        }
    }
}