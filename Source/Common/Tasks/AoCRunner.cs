using System;

namespace mbaaz.AdventOfCode2020.Common.Tasks
{
    public class AoCRunner
    {
        private readonly IWorker _worker;
        private readonly Settings.Settings _settings;
        private readonly Printer _printer;


        public AoCRunner(IWorker worker, Settings.Settings settings, Printer printer)
        {
            _worker = worker;
            _settings = settings;
            _printer = printer;
        }

        public void Run()
        {
            _printer.PrintSeparator();

            _printer.PrintHeaderSection("Advent of Code");

            _printer.PrintSection($"This is a solution to the problems published at {_settings.ProblemsMainUrl}. This project is created by {_settings.Author}.");

            _printer.PrintSeparator();

            var day = _worker.DayNumber.ToString().PadLeft(2, '0');
            _printer.PrintHeaderSection($" {_settings.Year} -- Day {day} ");

            var baseTaskResult = GetResult(() => _worker.SolveBaseTask());
            _printer.PrintSection($"Base Task Solution:{Environment.NewLine}> {baseTaskResult}");

            var extraTaskResult = GetResult(() => _worker.SolveExtraTask());
            _printer.PrintSection($"Extra Task Solution:{Environment.NewLine}> {extraTaskResult}");

            _printer.PrintSeparator();

            Exit();
        }

        public void Exit()
        {
            Console.WriteLine("");
            Console.Write("Press any key to exit: ");
            Console.Read();
        }

        private string GetResult(Func<IResult> action)
        {
            try
            {
                var result = action();
                return result.ToString();
            }
            catch (ApplicationException ex)
            {
                return $"App Error: {ex.Message}";
            }
            catch (NotImplementedException ex)
            {
                return "ERROR: This has not been solved yet!";
            }
            catch (Exception ex)
            {
                return "Internal Error - Unknown cause!";
            }
        }
    }
}