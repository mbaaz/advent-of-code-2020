using System.Collections.Generic;
using System.Linq;

namespace mbaaz.AdventOfCode2020.Day11.Models
{
    public static class RoomExtensions
    {
        private static readonly (int Row, int Col)[] SpaceOffsets = {
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1), (0, 1),
            (1, -1), (1, 0), (1, 1)
        };
        
        public static Room SimulateMovement(this Room room, int occupiedAdjacentSeatsToVacateLimit, AdjacentSeatPolicy seatPolicy, out int changes)
        {
            changes = 0;
            var newSpaces = new SpaceType[room.Rows, room.Cols];
            for (var row = 0; row < room.Rows; row++)
            {
                for (var col = 0; col < room.Cols; col++)
                {
                    var adjacentSpaces = GetSurroundingSpaces(room, row, col, seatPolicy).ToList();
                    newSpaces[row, col] = ApplyMovementRules(room.Spaces[row, col], adjacentSpaces, occupiedAdjacentSeatsToVacateLimit, out var isChange);
                    if (isChange)
                        changes++;
                }
            }

            return new Room(newSpaces);
        }

        private static IEnumerable<SpaceType> GetSurroundingSpaces(Room room, int row, int col, AdjacentSeatPolicy seatPolicy)
        {
            var offsets = SpaceOffsets.ToList();

            for (var i = 0; i < offsets.Count; i++)
            {
                var (rowOffset, colOffset) = offsets[i];
                var newRow = row + rowOffset;
                var newCol = col + colOffset;
                if (newRow >= 0 && newRow < room.Rows && newCol >= 0 && newCol < room.Cols)
                {
                    if(seatPolicy == AdjacentSeatPolicy.OnlyImmediateNeighbors || room.Spaces[newRow, newCol] != SpaceType.Floor)
                    {
                        yield return room.Spaces[newRow, newCol];
                        continue;
                    }
                    
                    if (seatPolicy == AdjacentSeatPolicy.NearestVisibleSeat)
                    {
                        var newOffset = (
                            rowOffset == 0 ? 0 : rowOffset < 0 ? rowOffset-1 : rowOffset+1,
                            colOffset == 0 ? 0 : colOffset < 0 ? colOffset-1 : colOffset+1
                        );
                        offsets.Add(newOffset);
                    }
                }
            }
        }

        private static SpaceType ApplyMovementRules(SpaceType space, List<SpaceType> adjacentSpaces, int occupiedAdjacentSeatsToVacateLimit, out bool isChange)
        {
            isChange = false;

            // Floor (.) never changes
            if (space == SpaceType.Floor)
                return SpaceType.Floor;

            // Rule 1: If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied.
            if (space == SpaceType.EmptySeat && adjacentSpaces.All(aSpace => aSpace != SpaceType.OccupiedSeat))
            {
                isChange = true;
                return SpaceType.OccupiedSeat;
            }
            
            // Rule 2: If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
            if (space == SpaceType.OccupiedSeat && adjacentSpaces.Count(aSpace => aSpace == SpaceType.OccupiedSeat) >= occupiedAdjacentSeatsToVacateLimit)
            {
                isChange = true;
                return SpaceType.EmptySeat;
            }

            // Rule 3: Otherwise, the seat's state does not change.
            return space;
        }
    }
}