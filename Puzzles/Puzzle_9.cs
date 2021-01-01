using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_9 : IPuzzle
    {
        private string[] seatNumbers;

        public Puzzle_9()
        {
            seatNumbers = Inputs.GetInput("Day5.txt").ToArray();
        }

        public string Run()
        {
            var columnPositions = new Dictionary<string, int>();
            var seatNumber = 0;
            var columnStringLength = 3;

            for(var i = 0; i < seatNumbers.Length; i++)
            {
                int rowHigh = BinarySearch(seatNumbers[i][..^columnStringLength], 'F') << 3;

                var key = seatNumbers[i][^columnStringLength..];
                if (!columnPositions.TryGetValue(key, out var column))
                {                 
                    columnPositions.Add(key, column = BinarySearch(key, 'L'));
                }

                var currentSeat = rowHigh + column;
                seatNumber = currentSeat > seatNumber ? currentSeat : seatNumber;
            }

            return seatNumber.ToString();
        }

        private int BinarySearch(string row, char lowIndex)
        {
            int minValue = 0, maxValue= (1 << row.Length) - 1;
            for (var i = 0; i < row.Length; i++)
            {
                var gap = (maxValue - minValue) / 2;
                if (row[i] == lowIndex)
                {
                    maxValue = minValue + gap;
                }
                else
                {
                    minValue = maxValue - gap;
                }
            }

            return maxValue;
        }
    }
}
