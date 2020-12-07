using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day02
{
    internal class ResultModel : IResult
    {
        private readonly int _validPasswords;
        private readonly int _totalPassword;
        
        public ResultModel(int validPasswords, int totalPassword)
        {
            _validPasswords = validPasswords;
            _totalPassword = totalPassword;
        }

        public override string ToString()
        {
            return $"{_validPasswords} are valid (of {_totalPassword} in total).";
        }
    }
}