using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day06
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 6;

        private readonly List<string> _input;

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = rawInput.ToList();
        }

        public IResult SolveBaseTask()
        {
            // My idea here is to use the first 26 bits in an int to store
            // the answers. Int has 31 unsigned bits, which is enough.
            // An a will put a 1 in position 0, B: 1 in pos 1,
            // Z: 1 in pos 26 etc..
            
            var sum = 0;
            int groupAnswers = 0;
            foreach (var row in _input)
            {
                if (string.IsNullOrEmpty(row))
                {
                    sum += CountAnswers(groupAnswers);
                    groupAnswers = 0; // reset answers
                    continue;
                }

                groupAnswers |= row.Aggregate(0, (mem, c) => mem | 1 << GetIndex(c));
            }
            sum += CountAnswers(groupAnswers);
            return new ResultModel(sum);
        }
        
        public IResult SolveExtraTask()
        {
            // This will represent a number with the first 26 bits as 1s, the others 0s.
            // int.MaxValue will set all 31 value-bits to 1s (0x01111111111111111111111111).
            // 31 represents a 5-bit value with all 1s, shifted 26 steps means five 1s followed by 26 0s (0x01111100000000000000000000000000)
            // XOR (^) converts this into 0x00000011111111111111111111111111). This means all available answers (a-z) are defaulted to yes.
            var empty = int.MaxValue ^ (31 << 26);
            
            // This way, "empty" means that all questions are answered.
            // Performing AND-operations for each answer in group will render
            // 1s in the places where all have answered that question the same.
            
            var sum = 0;
            var groupAnswers = empty;
            var groupDirty = false; // Need to keep track of this, otherwise a "blank" group will have answered 26 questions the same way
            foreach (var row in _input)
            {
                if (string.IsNullOrEmpty(row))
                {
                    if (groupDirty)
                    {
                        sum += CountAnswers(groupAnswers);
                        groupAnswers = empty; // reset answers
                        groupDirty = false;
                    }
                    continue;
                }

                groupAnswers &= row.Aggregate(0, (mem, c) => mem | 1 << GetIndex(c));
                groupDirty = true;
            }

            if (groupDirty)
            {
                sum += CountAnswers(groupAnswers);
            }
            
            return new ResultModel(sum);
        }
        
        // Get the position of the letter in the alphabet
        private int GetIndex(char answer)
            => (int) answer - (int) 'a';

        // Convert the int into binary representation and count the 1s
        private int CountAnswers(int value)
            => Convert.ToString(value, 2).Count(c => c == '1');
    }
}