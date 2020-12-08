using System.Collections.Generic;
using mbaaz.AdventOfCode2020.Common.Models;

namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public static class HeightExtensions
    {
        private static readonly Dictionary<string, HeightUnit> parseHeightUnits = new()
        {
            { "cm", HeightUnit.Centimeters },
            { "in", HeightUnit.Inches }
        };

        public static HeightUnit ToHeightUnit(this string strHeightUnit)
        {
            return parseHeightUnits.ContainsKey(strHeightUnit.ToLower())
                ? parseHeightUnits[strHeightUnit.ToLower()]
                : HeightUnit.Unknown
            ;
        }

        public static bool IsValid(this Height height)
        {
            var heightCentimeterRange = new Range<int>(150, 193);
            var heightInchesRange = new Range<int>(59, 76);

            if (height == null || height.Unit == HeightUnit.Unknown)
                return false;

            if (height.Unit == HeightUnit.Centimeters)
                return heightCentimeterRange.WithinRange(height.Quantity);

            if (height.Unit == HeightUnit.Inches)
                return heightInchesRange.WithinRange(height.Quantity);

            // Unknown height unit
            return false;
        }
    }
}