using System.Text.RegularExpressions;
using mbaaz.AdventOfCode2020.Common.Models;

namespace mbaaz.AdventOfCode2020.Day02.Models
{
    public static class PasswordRecordExtensions
    {
        private static readonly Regex _matchExpression;

        static PasswordRecordExtensions()
        {
            _matchExpression = new Regex("^(?<From>\\d+)\\-(?<To>\\d+) (?<Sequence>\\w): (?<Password>\\w+)", RegexOptions.IgnoreCase);
        }
        
        public static PasswordRecord ParseAsPasswordRecord(this string strRecord)
        {
            var match = _matchExpression.Match(strRecord);
            if (!match.Success)
                return null;
            
            var password = match.Groups["Password"].Value;
            var sequence = match.Groups["Sequence"].Value[0];
            var from = int.Parse(match.Groups["From"].Value);
            var to = int.Parse(match.Groups["To"].Value);
            return new PasswordRecord(password, new PasswordRule(sequence, new Range<int>(from, to)));
        }

        public static bool IsValidAccordingToFirstTaskRules(this PasswordRecord record)
        {
            var count = GetCount(record.Rule.Sequence, record.Password);
            return record.Rule.Occurences.WithinRange(count);
        }

        private static int GetCount(char needle, string haystack)
        {
            var count = 0;
            foreach (var c in haystack)
            {
                if (c == needle)
                    count++;
            }
            return count;
        }

        public static bool IsValidAccordingToSecondTaskRules(this PasswordRecord record)
        {
            var isFirstMatch = record.Password[record.Rule.Occurences.From - 1] == record.Rule.Sequence;
            var isSecondMatch = record.Password[record.Rule.Occurences.To - 1] == record.Rule.Sequence;
            return isFirstMatch ^ isSecondMatch;
        }
    }
}