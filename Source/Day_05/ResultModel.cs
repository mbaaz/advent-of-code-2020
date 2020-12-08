using mbaaz.AdventOfCode2020.Common.Tasks;
using mbaaz.AdventOfCode2020.Day05.Models;

namespace mbaaz.AdventOfCode2020.Day05
{
    internal class ResultModel : IResult
    {
        public Ticket Ticket { get; }
        
        public ResultModel(Ticket ticket)
        {
            Ticket = ticket;
        }

        public override string ToString()
        {
            return $"Selected ticket: {Ticket}";
        }
    }
}