using System.Linq;
using System.Text.RegularExpressions;

namespace mbaaz.AdventOfCode2020.Day07.Models
{
    public record Bag
    {
        public string Color { get; }
        public Content[] Content { get; }

        public Bag(string color, Content[] content)
        {
            Color = color;
            Content = content;
        }

        private static readonly Regex Parser = new("^(?<Color>[\\w ]+) bags contain ((?<NoContent>no other bags)|(?<Content>((, )?\\d+ [\\w ]+ bags?)*))\\.$", RegexOptions.IgnoreCase);
        
        public static Bag Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            var match = Parser.Match(str);
            if (!match.Success)
                return null;

            var color = match.Groups["Color"].Value;
            if (match.Groups["NoContent"].Value.Any())
                return new Bag(color, null);
            
            var content = match.Groups["Content"].Value
                .Split(", ")
                .Select(Models.Content.Parse)
                .Where(item => item != null)
                .ToArray()
            ;
            return new Bag(color, content);
        }
    }
}