using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mbaaz.AdventOfCode2020.Day12.Models.NavigationInstructions
{
    public static class NavigationInstruction
    {
        private static readonly Regex Parser = new("^(?<Direction>[NSEWLRF])(?<Value>\\d+)$", RegexOptions.IgnoreCase);
        
        private static readonly Dictionary<char, Func<int, INavigationInstruction>> NavigationInstructionFactory = new()
        {
            { 'N', (value) => new NorthNavigationInstruction(value) },
            { 'S', (value) => new SouthNavigationInstruction(value) },
            { 'E', (value) => new EastNavigationInstruction(value) },
            { 'W', (value) => new WestNavigationInstruction(value) },
            { 'L', (value) => new LeftNavigationInstruction(value) },
            { 'R', (value) => new RightNavigationInstruction(value) },
            { 'F', (value) => new ForwardNavigationInstruction(value) },
        };
        
        public static INavigationInstruction Parse(string instruction)
        {
            if (string.IsNullOrEmpty(instruction))
                return null;

            var match = Parser.Match(instruction);
            if (!match.Success)
                return null;

            var direction = match.Groups["Direction"].Value[0];
            var value = int.Parse(match.Groups["Value"].Value);
            return NavigationInstructionFactory[direction](value);
        }
    }
}