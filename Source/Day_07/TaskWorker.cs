using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day07.Models;

namespace mbaaz.AdventOfCode2020.Day07
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 7;

        private readonly List<Bag> _bags;

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _bags = ProcessInput(rawInput);
        }

        private static List<Bag> ProcessInput(IEnumerable<string> input)
        {
            // Parse all the bags. This will however not link them together.
            var bags = input.Select(Bag.Parse).Where(bag => bag != null).ToList();
            
            // Build the tree. Replace all bags in Bag.Content,
            // That way, they will all link together.
            foreach (var bag in bags)
            {
                if(bag.Content == null || !bag.Content.Any())
                    continue;

                
                for (var i = 0; i < bag.Content.Length; i++)
                {
                    var amount = bag.Content[i].Amount;
                    var realBag = bags.FirstOrDefault(item => item.Color == bag.Content[i].Bag.Color);
                    bag.Content[i] = new Content(amount, realBag);
                }
            }
            return bags;
        }
        
        public IResult SolveBaseTask()
        {
            var colorToFind = "shiny gold";
            var bagsThatCanContainColor = _bags.Count(bag => bag.Color != colorToFind && bag.CanContainBagOfColor(colorToFind));
            return new BaseTaskResultModel(colorToFind, bagsThatCanContainColor);
        }

        public IResult SolveExtraTask()
        {
            var colorToFind = "shiny gold";
            var bagCount = _bags.FirstOrDefault(item => colorToFind == item.Color).InnerBagCount();
            return new ExtraTaskResultModel(colorToFind, bagCount);
        }
    }
}