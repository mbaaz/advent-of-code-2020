using System;

namespace mbaaz.AdventOfCode2020.Day02
{
    public static class RangeExtensions
    {
        public static bool WithinRange<T>(this Range<T> range, T value)
            where T: IComparable
        {
            if (range == null)
                throw new ArgumentNullException(nameof(range));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return range.From.CompareTo(value) <= 0 &&
                   range.To.CompareTo(value) >= 0;
        }
    }
}