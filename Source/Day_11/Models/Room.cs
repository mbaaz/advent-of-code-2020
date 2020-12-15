namespace mbaaz.AdventOfCode2020.Day11.Models
{
    public record Room
    {
        public SpaceType[,] Spaces { get; }

        private int? _occupiedSeats;
        public int OccupiedSeats => _occupiedSeats ??= CalculateSeatsOfType(SpaceType.OccupiedSeat);
        
        private int? _emptySeats;
        public int EmptySeats => _emptySeats ??= CalculateSeatsOfType(SpaceType.EmptySeat);
        
        private int? _floorSpaces;
        public int FloorSpaces => _floorSpaces ??= CalculateSeatsOfType(SpaceType.Floor);

        private int? _rows;
        public int Rows => _rows ??= Spaces.GetLength(0);

        private int? _cols;
        public int Cols => _cols ??= Spaces.GetLength(1);
        
        
        public Room(SpaceType[,] spaces)
        {
            Spaces = spaces;
        }

        private int CalculateSeatsOfType(SpaceType spaceType)
        {
            if (Spaces == null)
                return 0;

            var result = 0;
            for (var i = 0; i < Spaces.GetLength(0); i++)
            {
                for (var j = 0; j < Spaces.GetLength(1); j++)
                {
                    if (Spaces[i, j] == spaceType)
                        result++;
                }
            }

            return result;
        }
    }
}