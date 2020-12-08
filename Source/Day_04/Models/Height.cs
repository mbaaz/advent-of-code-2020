using System.Text.RegularExpressions;

namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public record Height
    {
        public int Quantity { get; }
        public HeightUnit Unit { get; }

        public Height(int quantity, HeightUnit unit)
        {
            Quantity = quantity;
            Unit = unit;
        }

        private static readonly Regex ParseRegex = new Regex("^(?<Quantity>\\d+)(?<Unit>\\D+)?$", RegexOptions.IgnoreCase);
        
        public static Height Parse(string str)
        {
            var match = ParseRegex.Match(str);
            if (!match.Success)
                return null;

            var quantity = int.Parse(match.Groups["Quantity"].Value);
            var heightUnit = match.Groups["Unit"].Value.ToHeightUnit();
            return new Height(quantity, heightUnit);
        }
    }
}