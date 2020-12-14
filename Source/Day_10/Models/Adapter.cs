using System.Collections.Generic;
using System.Linq;

namespace mbaaz.AdventOfCode2020.Day10.Models
{
    public record Adapter
    {
        public int Jolts { get; }
        public List<Adapter> NextAdapters { get; }

        private long? _weight;
        public long Weight => _weight ??= CalculateWeight();
        
        public Adapter(int jolts)
        {
            Jolts = jolts;
            NextAdapters = new List<Adapter>();
        }

        public void AddNextAdapter(Adapter adapter)
        {
            if (adapter.Jolts > Jolts && adapter.Jolts - Jolts <= 3)
            {
                NextAdapters.Add(adapter);
            }
        }
        
        private long CalculateWeight()
        {
            if (NextAdapters.Count == 0)
                return 1;
            return NextAdapters.Sum(adapter => adapter.Weight);
        }
    }
}