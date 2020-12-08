namespace mbaaz.AdventOfCode2020.Day02.Models
{
    public record PasswordRecord 
    {
        public string Password { get; }
        public PasswordRule Rule { get; }

        public PasswordRecord(string password, PasswordRule rule)
        {
            Password = password;
            Rule = rule;
        }
    }
}