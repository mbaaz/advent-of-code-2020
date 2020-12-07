using System.Linq;
using mbaaz.AdventOfCode2020.Common.Tasks;

namespace mbaaz.AdventOfCode2020.Day03
{
    internal class ExtraTaskResultModel : IResult
    {
        public int[] Encounters { get; }

        public long EncounterProduct => Encounters?.Aggregate((long)1, (a, b) => (long)a * (long)b) ?? 0;
        
        public ExtraTaskResultModel(int[] encounters)
        {
            Encounters = encounters;
        }

        public override string ToString()
        {
            var encounters = string.Join(", ", Encounters);
            return $"{EncounterProduct} (product of all encounters) {encounters}";
        }
    }
}