using System;

namespace mbaaz.AdventOfCode2020.Day05.Models
{
    public record Ticket
    {
        public int Row { get; }
        public int Seat { get; }
        public int ID { get; }
        
        public Ticket(int row, int seat)
        {
            Row = row;
            Seat = seat;
            ID = (Row * 8) + Seat;
        }

        public static Ticket Parse(string seatId)
        {
            if (seatId == null)
                throw new ArgumentNullException(nameof(seatId));

            if (seatId.Length != 10)
                throw new ApplicationException("SeatId should be a 10 char string");
            
            
            var row = seatId
                .Substring(0, 7)
                .Replace('F', '0')
                .Replace('B', '1')
                .BinToDec()
            ;
            
            var seat = seatId
                .Substring(7, 3)
                .Replace('L', '0')
                .Replace('R', '1')
                .BinToDec()
            ;

            return new Ticket(row, seat);
        }

        public static Ticket Parse(int seatId)
        {
            var seat = seatId % 8;
            var row = (seatId - seat) / 8;
            return new Ticket(row, seat);
        }
    }
}