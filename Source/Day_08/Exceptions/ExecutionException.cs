using System;
using mbaaz.AdventOfCode2020.Day08.Models;

namespace mbaaz.AdventOfCode2020.Day08.Exceptions
{
    public class ExecutionException : ApplicationException
    {
        public ExecutionContext Context { get; }

        public ExecutionException(ExecutionContext context, string message)
            : base(message)
        {
            Context = context;
        }
    }
}