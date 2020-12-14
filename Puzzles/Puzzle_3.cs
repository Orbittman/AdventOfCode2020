using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_3 : IPuzzle
    {
        public string Run()
        {
            var input = File.ReadLines("./Puzzle3.txt");
            var counter = 0;
            foreach(var item in input)
            {
                var pattern = item.Substring(0, item.IndexOf(' ')).Split("-").Select(i => int.Parse(i));
                var character = item.Substring(item.IndexOf( ' ') + 1, 1);
                var inputString = item.Substring(item.LastIndexOf(' ') + 1);
                var regex = new Regex($"{character}");
                var match = regex.Matches(inputString);
                if (match.Count >= pattern.ElementAt(0) && match.Count <= pattern.ElementAt(1))
                {
                    counter++;
                }
            }

            return counter.ToString();
        }
    }
}
