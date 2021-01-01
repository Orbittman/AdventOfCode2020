using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Puzzles
{
    public class TestPuzzle
    {
        private string[] seatNumbers;

        public TestPuzzle()
        {
            seatNumbers = Inputs.GetInput("Day5.txt").ToArray();
        }

        public string Run()
        {
            var seatIds = seatNumbers.Select(GetSeatId)
  .ToImmutableSortedSet();

            return seatIds.Max().ToString();

            //Console.WriteLine(Enumerable
            //  .Range(seatIds.Min(), seatIds.Count + 1)
            //  .SingleOrDefault(id => !seatIds.Contains(id)));

            static int GetSeatId(string pass)
            {
                var binary = new StringBuilder(pass)
                  .Replace('F', '0')
                  .Replace('B', '1')
                  .Replace('L', '0')
                  .Replace('R', '1')
                  .ToString();

                return Convert.ToInt32(binary, 2);
            }
        }
    }
}