using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mbaaz.AdventOfCode2020.Day08.Models
{
    public abstract class Instruction
    {
        // These are all the available instructions
        private static readonly Dictionary<string, Func<int, IInstruction>> InstructionFactory = new()
        {
            { AccumulatorInstruction.OperationName, (arg) => new AccumulatorInstruction(arg) },
            { JumpInstruction.OperationName,        (arg) => new JumpInstruction(arg) },
            { NoOperationInstruction.OperationName, (arg) => new NoOperationInstruction(arg) }
        };
        
        private static readonly Regex Parser = new("^(?<Operation>\\w+) (?<Argument>[+-]\\d+)$", RegexOptions.IgnoreCase);
        
        public static IInstruction Parse(string strInstruction)
        {
            if (string.IsNullOrEmpty(strInstruction))
                return null;

            var match = Parser.Match(strInstruction);
            if (!match.Success)
                return null;

            var operation = match.Groups["Operation"].Value;
            var argument = int.Parse(match.Groups["Argument"].Value);
            var instruction = InstructionFactory[operation](argument);
            return instruction;
        }
    }
}