using System;
using System.Collections.Generic;

namespace mbaaz.AdventOfCode2020.Day11.Models
{
    public static class SpaceTypeExtensions
    {
        private static readonly Dictionary<char, SpaceType> SpaceTypeTokens = new()
        {
            { '#', SpaceType.OccupiedSeat },
            { 'L', SpaceType.EmptySeat },
            { '.', SpaceType.Floor }
        };

        public static SpaceType ToSpaceType(this char spaceTypeToken)
        {
            if (SpaceTypeTokens.ContainsKey(spaceTypeToken))
                return SpaceTypeTokens[spaceTypeToken];

            throw new ArgumentException($"Unknown Space Type Token \"{spaceTypeToken}\".");
        }
    }
}