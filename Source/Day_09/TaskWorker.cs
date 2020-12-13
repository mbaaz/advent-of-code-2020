using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day09
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 9;

        private readonly List<long> _input;

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        private static List<long> ProcessInput(IEnumerable<string> input)
            => input.Select(long.Parse).ToList();

        
        public IResult SolveBaseTask()
        {
            for (var i = 25; i < _input.Count; i++)
            {
                var skip = Math.Max(i - 25, 0);
                var take = Math.Min(25, i);
                var preamble = _input.Skip(skip).Take(take).ToList();
                
                if (!HasPairSum(preamble, _input[i]))
                    return new ResultModel(_input[i]);
            }

            throw new ApplicationException("Could not find a number that matches the criteria!");
        }

        public IResult SolveExtraTask()
        {
            long target = 70639851;

            for (var i = 0; i < _input.Count - 1; i++)
            {
                long rangeSum = _input[i];
                for (var j = i + 1; j < _input.Count; j++)
                {
                    rangeSum += _input[j];
                    if (rangeSum > target)
                        break;
                    if (rangeSum == target)
                        return new ResultModel(PostProcessResultRange(i, j));

                }
            }
            
            throw new ApplicationException("Could not find a number that matches the criteria!");
        }

        private static bool HasPairSum(List<long> values, long sumToFind)
        {
            values.Sort();
            for (var i = 0; i < values.Count-1; i++)
            {
                if (values.IndexOf(sumToFind - values[i], i + 1) > -1)
                    return true;
            }

            return false;
        }

        private long PostProcessResultRange(int startIndex, int endIndex)
        {
            var range = _input.Skip(startIndex).Take(endIndex - startIndex + 1).ToList();
            var smallest = range.Min();
            var largest = range.Max();
            return smallest + largest;
        }
    }
}