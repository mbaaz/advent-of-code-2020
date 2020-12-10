using System.Text.RegularExpressions;

namespace mbaaz.AdventOfCode2020.Day07.Models
{
    public record Content
    {
        public int Amount { get; }
        public Bag Bag { get; set; }

        public Content(int amount, Bag bag)
        {
            Amount = amount;
            Bag = bag;
        }

        private static readonly Regex Parser = new("^(?<Amount>\\d+) (?<Color>[\\w ]+) bags?$", RegexOptions.IgnoreCase);
        
        public static Content Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            var match = Parser.Match(str);
            if (!match.Success)
                return null;

            var amount = int.Parse(match.Groups["Amount"].Value);
            var color = match.Groups["Color"].Value;
            return new Content(amount, new Bag(color, null));
        }
    }
}