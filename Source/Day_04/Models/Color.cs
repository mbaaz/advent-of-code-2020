using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public static class Color
    {
        private static readonly Regex CodedColorPattern = new("^#(?<Code>[\\da-f]{6})$", RegexOptions.IgnoreCase);

        private static readonly Dictionary<string, ColorName> NamedColorLookup = new()
        {
            { "amb", ColorName.Amber },
            { "blu", ColorName.Blue },
            { "brn", ColorName.Brown },
            { "gry", ColorName.Gray },
            { "grn", ColorName.Green },
            { "hzl", ColorName.Hazel },
            { "oth", ColorName.Other },
        };
        
        public static IColor Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            if (NamedColorLookup.ContainsKey(str))
                return new NamedColor(NamedColorLookup[str]);

            var match = CodedColorPattern.Match(str);
            if (match.Success)
                return new CodedColor(match.Groups["Code"].Value);

            return new UndefinedColor(str);
        }
    }
}