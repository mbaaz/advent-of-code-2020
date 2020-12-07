namespace mbaaz.AdventOfCode2020.Common.Tasks
{
    public interface IWorker
    {
        int DayNumber { get; }
        
        IResult SolveBaseTask();
        IResult SolveExtraTask();
    }
}