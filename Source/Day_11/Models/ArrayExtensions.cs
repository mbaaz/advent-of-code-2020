using System;
using System.Linq;

namespace mbaaz.AdventOfCode2020.Day11.Models
{
    public static class ArrayExtensions 
    {
        // Taken from here: https://stackoverflow.com/questions/26291609/converting-jagged-array-to-2d-array-c-sharp
        public static T[,] To2D<T>(this T[][] source)
        {
            try
            {
                var firstDim = source.Length;
                var secondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[firstDim, secondDim];
                for (int i = 0; i < firstDim; ++i)
                for (int j = 0; j < secondDim; ++j)
                    result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            } 
        }
    }
}