namespace mbaaz.AdventOfCode2020.Common.Settings
{
    public class Settings : ISettings
    {
        public string SectionName => "Settings";

        public int Year { get; set; }
        public Author Author { get; set; }

        public string ProblemsMainUrl { get; set; }
        public string DailyProblemUrlFormat { get; set; }
        public string SessionID { get; set; }
    }
}