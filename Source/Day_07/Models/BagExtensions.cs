using System.Linq;

namespace mbaaz.AdventOfCode2020.Day07.Models
{
    public static class BagExtensions
    {
        public static bool CanContainBagOfColor(this Bag bag, string color)
            => bag.Color == color || (bag.Content != null && bag.Content.Any(content => CanContainBagOfColor(content.Bag, color)));

        public static int InnerBagCount(this Bag bag)
            => bag.Content?.Sum(content => content.Amount * (1 + content.Bag.InnerBagCount())) ?? 0; // The one represents the actual child bag, plus all the inner bags in that
    }
}