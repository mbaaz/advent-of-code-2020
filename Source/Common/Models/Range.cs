using System;

namespace mbaaz.AdventOfCode2020.Common.Models
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