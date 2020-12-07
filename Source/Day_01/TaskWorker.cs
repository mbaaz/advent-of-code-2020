using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day01
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 1;

        private readonly List<int> _input;

        // This is the product we are adding up to from the data input file
        private const int Result = 2020;


        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        // Parse raw input into an ordered list of ints
        private static List<int> ProcessInput(IEnumerable<string> strings)
            => strings?.Select(int.Parse).OrderBy(num => num).ToList();

        private void VerifyInputAvailable()
        {
            if(_input == null)
                throw new ApplicationException("Input is unavailable!");
        }

        public IResult SolveBaseTask()
        {
            VerifyInputAvailable();

            // Find the result for 2 numbers
            var result = GetResult(2);
            return result;
        }

        public IResult SolveExtraTask()
        {
            VerifyInputAvailable();

            // Find the result for 3 numbers
            var result = GetResult(3);
            return result;
        }

        private ResultModel GetResult(int numberOfElements)
        {
            var result = GetResult(numberOfElements, new List<int>());
            if (result == null)
                throw new ApplicationException("Could not find solution to problem!");

            var numbers = result.Select(i => _input[i]).ToArray();
            return new ResultModel(numbers);
        }

        private List<int> GetResult(int targetElements, List<int> elementIndexes, int currentElements = 0, int nextIndex = 0)
        {
            for (var newIndex = nextIndex; newIndex <= _input.Count - targetElements + currentElements; newIndex++)
            {
                var newList = new List<int>(elementIndexes) { newIndex };

                var sum = newList.Select(i => _input[i]).Sum();
                if (sum > Result)
                    break;

                // Last iterator
                if (currentElements == targetElements - 1)
                {
                    if (sum == Result)
                        return newList;
                }

                // Otherwise, need to re-iterate to add more indexes
                else
                {
                    var res = GetResult(targetElements, newList, currentElements + 1, newIndex + 1);
                    if (res != null)
                        return res;
                }
            }

            return null;
        }
    }
}