using System;

namespace mbaaz.AdventOfCode2020.Day02
{
    public record Range<T> 
        where T: IComparable
    {
        public T From { get; }
        public T To { get; }

        public Range(T from, T to)
        {
            From = from;
            To = to;
        }
    }
}