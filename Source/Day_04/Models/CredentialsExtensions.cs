using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using mbaaz.AdventOfCode2020.Common.Models;

namespace mbaaz.AdventOfCode2020.Day04.Models
{
    public static class CredentialsExtensions
    {
        private static readonly Dictionary<string, Action<string, Credentials>> PropertySetters = new()
        {
            { "byr", (value, credentials) => credentials.BirthYear      = YearRecord.Parse(value) },
            { "iyr", (value, credentials) => credentials.IssueYear      = YearRecord.Parse(value) },
            { "eyr", (value, credentials) => credentials.ExpirationYear = YearRecord.Parse(value) },
            { "hgt", (value, credentials) => credentials.Height     = Height.Parse(value) },
            { "hcl", (value, credentials) => credentials.HairColor  = Color.Parse(value) },
            { "ecl", (value, credentials) => credentials.EyeColor   = Color.Parse(value) },
            { "pid", (value, credentials) => credentials.PassportID = value },
            { "cid", (value, credentials) => credentials.CountryID  = value },
        };
        
        public static Credentials ParseAsCredentials(this IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            // Create a new Credentials
            var credentials = new Credentials();

            // Call the setter for each key/value
            foreach (var (key, value) in keyValuePairs)
            {
                PropertySetters[key](value, credentials);
            }
            
            // Return credentials
            return credentials;
        }

        public static bool IsValidPassport(this Credentials credentials)
        {
            return credentials != null
                && credentials.BirthYear != null
                && credentials.IssueYear != null
                && credentials.ExpirationYear != null
                && credentials.Height != null
                && credentials.HairColor != null
                && credentials.EyeColor != null
                && !string.IsNullOrEmpty(credentials.PassportID)
             // && !string.IsNullOrEmpty(credentials.CountryID) <-- Disabled to allow for North Pole-credentials to pass
            ;
        }
        
        public static bool IsExtraValidPassport(this Credentials credentials)
        {
            var birthYearRange = new Range<int>(1920, 2002);
            var issueYearRange = new Range<int>(2010, 2020);
            var expirationYearRange = new Range<int>(2020, 2030);
            var pidTest = new Regex("^\\d{9}$", RegexOptions.IgnoreCase);
            
            return credentials != null
                   && birthYearRange.WithinRange(credentials.BirthYear.Year)
                   && issueYearRange.WithinRange(credentials.IssueYear.Year)
                   && expirationYearRange.WithinRange(credentials.ExpirationYear.Year)
                   && credentials.Height.IsValid()
                   && credentials.HairColor?.GetType() == typeof(CodedColor)
                   && credentials.EyeColor?.GetType() == typeof(NamedColor)
                   && pidTest.IsMatch(credentials.PassportID ?? "")
                // && !string.IsNullOrEmpty(credentials.CountryID) <-- Disabled to allow for North Pole-credentials to pass
            ;
        }
    }
}