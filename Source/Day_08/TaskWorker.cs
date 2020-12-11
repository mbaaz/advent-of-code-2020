using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day08.Exceptions;
using mbaaz.AdventOfCode2020.Day08.Models;

namespace mbaaz.AdventOfCode2020.Day08
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 8;

        private readonly IInstruction[] _instructions;

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _instructions = ProcessInput(rawInput);
        }

        private static IInstruction[] ProcessInput(IEnumerable<string> input)
            => input.Select(Instruction.Parse).ToArray();

        public IResult SolveBaseTask()
        {
            var program = new Models.Program(_instructions);

            try
            {
                program.Execute();
            }
            catch (InfiniteLoopExecutionException ex)
            {
                // Hooray - an infinite loop was detected!
                return new ResultModel(ex.Context.Accumulator);
            }

            throw new ApplicationException("No loop was detected! ;-(");
        }

        public IResult SolveExtraTask()
        {
            var jmpInstruction = typeof(JumpInstruction);
            var nopInstruction = typeof(NoOperationInstruction);
            
            // Loop over all instructions
            for (var i = 0; i < _instructions.Length; i++)
            {
                var instructionType = _instructions[i].GetType();
                if (instructionType != jmpInstruction && instructionType != nopInstruction)
                    continue;

                // Make a copy of the instruction list
                var newList = _instructions.ToArray();
                
                // Exchange the instruction in position [i] according to task details
                newList[i] = SwitchInstructionType(newList[i]);
                
                // Try to execute a program according to these new instructions
                // If the programs ends gracefully (no exception), a solution has been found!
                try
                {
                    var program = new Models.Program(newList);
                    var context = program.Execute();
                    return new ResultModel(context.Accumulator);
                }
                catch (ExecutionException)
                {
                    // We swallow these - current instruction switch was not the correct one!
                    
                }
            }

            throw new ApplicationException("No solution to the problem was found!");
        }

        private static IInstruction SwitchInstructionType(IInstruction instruction)
        {
            if (instruction == null)
                throw new ArgumentNullException(nameof(instruction));
            
            
            if (instruction.GetType() == typeof(JumpInstruction))
                return new NoOperationInstruction(instruction.Argument);

            if (instruction.GetType() == typeof(NoOperationInstruction))
                return new JumpInstruction(instruction.Argument);

            return instruction;
        }
    }
}