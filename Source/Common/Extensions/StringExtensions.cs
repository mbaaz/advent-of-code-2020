using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbaaz.AdventOfCode2020.Common
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitToLines(this string text, int maxLength)
        {
            var lines = text?
                .Split(Environment.NewLine)
                .SelectMany(txt => CombineToLines(txt.Split(' '), maxLength))
            ;
            return lines;
        }

        private static IEnumerable<string> CombineToLines(IEnumerable<string> words, int maxLength)
        {
            var line = new StringBuilder();

            foreach (var word in words)
            {
                var word2 = word;

                if (line.Length + word2.Length < maxLength)
                {
                    line.Append(word2 + ' ');
                    continue;
                }

                if (line.Length > 0)
                {
                    yield return line.ToString().Trim();
                    line.Clear();
                }

                while (word2.Length > maxLength)
                {
                    yield return word2.Substring(0, maxLength - 1) + '-';
                    word2 = word2.Substring(maxLength - 1);
                }

                line.Append(word2 + ' ');
            }

            yield return line.ToString().Trim();
        }
    }
}