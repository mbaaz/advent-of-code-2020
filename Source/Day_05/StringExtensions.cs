using System;

namespace mbaaz.AdventOfCode2020.Day05
{
    public static class StringExtensions
    {
        public static int BinToDec(this string binStr)
        {
            return Convert.ToInt32(binStr, 2);
        }
    }
}