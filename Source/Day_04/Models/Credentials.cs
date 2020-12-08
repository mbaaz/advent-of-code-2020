namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public class Credentials
    {
        public YearRecord BirthYear { get; set; }
        public YearRecord IssueYear { get; set; }
        public YearRecord ExpirationYear { get; set; }
        public Height Height { get; set; }
        public IColor HairColor { get; set; }
        public IColor EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }
    }
}