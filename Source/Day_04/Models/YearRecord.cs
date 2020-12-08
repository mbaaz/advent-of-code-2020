namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public record YearRecord
    {
        public int Year { get; }

        public YearRecord(int year)
        {
            Year = year;
        }

        public static YearRecord Parse(string strYear)
        {
            return int.TryParse(strYear, out int year)
                    ? new YearRecord(year)
                    : null
                ;
        }
    }
}