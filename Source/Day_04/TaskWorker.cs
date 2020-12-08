using System.Collections.Generic;
using System.Linq;
using System.Text;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day04.Models;

namespace mbaaz.AdventOfCode2020.Day04
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 4;

        private readonly List<Credentials> _input;

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _input = ProcessInput(rawInput);
        }

        private static List<Credentials> ProcessInput(IEnumerable<string> input)
        {
            var credentials = GatherData(input)
                .Select(ProcessInputRow)
                .Select(keyValuePairs => keyValuePairs.ParseAsCredentials())
                .ToList()
            ;
            return credentials;
        }

        /// <summary>
        /// This will pre-process the input and all data that belongs together on a single line.
        /// This will help parsing in the next step.
        /// </summary>
        /// <param name="input">The raw input from task</param>
        /// <returns>A gathered list where all key-value pairs that belong together is on the same line</returns>
        private static List<string> GatherData(IEnumerable<string> input)
        {
            var list = new List<string>();
            var builder = new StringBuilder();
            foreach (var row in input)
            {
                if (string.IsNullOrEmpty(row))
                {
                    list.Add(builder.ToString().Trim());
                    builder.Clear();
                    continue;
                }

                builder.Append(row + " ");
            }

            // Do not forget the last one!
            if(builder.Length > 0)
                list.Add(builder.ToString().Trim());
            
            return list;
        }

        private static IEnumerable<KeyValuePair<string, string>> ProcessInputRow(string row)
        {
            var keyValues = row.Split(' ');
            foreach (var keyValue in keyValues)
            {
                var index = keyValue.IndexOf(':');
                var key   = keyValue.Substring(0, index);
                var value = keyValue.Substring(index + 1);
                yield return new KeyValuePair<string, string>(key, value);
            }
        }

        public IResult SolveBaseTask()
        {
            var validPassports = _input.Count(credentials => credentials.IsValidPassport());
            var totalPassports = _input.Count;
            return new ResultModel(validPassports, totalPassports);
        }

        public IResult SolveExtraTask()
        {
            var validPassports = _input.Count(credentials => credentials.IsExtraValidPassport());
            var totalPassports = _input.Count;
            return new ResultModel(validPassports, totalPassports);
        }
    }
}