using System;
using System.Collections.Generic;
using System.Linq;
using mbaaz.AdventOfCode2020.Common.Settings;
using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day05.Models;

namespace mbaaz.AdventOfCode2020.Day05
{
    public class TaskWorker : Worker, IWorker
    {
        public override int DayNumber => 5;

        private readonly List<Ticket> _tickets;

        public TaskWorker(Settings settings)
            : base(settings)
        {
            var rawInput = GetTaskInput();
            _tickets = ProcessInput(rawInput);
        }

        private static List<Ticket> ProcessInput(IEnumerable<string> input)
            => input.Select(row => Ticket.Parse(row)).OrderBy(ticket => ticket.ID).ToList();
        
        public IResult SolveBaseTask()
        {
            return new ResultModel(_tickets.Last());
        }

        public IResult SolveExtraTask()
        {
            var firstId = _tickets.First().ID;
            for (var i = 1; i < _tickets.Count; i++)
            {
                if (_tickets[i].ID != firstId + i)
                    return new ResultModel(Ticket.Parse(firstId + i));
            }

            throw new NotImplementedException();
        }
    }
}