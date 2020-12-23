using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_4 : IPuzzle
    {
        public string Run()
        {
            var input = File.ReadLines("./Day2.txt");
            var counter = 0;
            foreach(var item in input)
            {
                var pattern = item.Substring(0, item.IndexOf(' ')).Split("-").Select(i => int.Parse(i)).ToArray();
                var character = item.Substring(item.IndexOf( ' ') + 1, 1);
                var inputString = item.Substring(item.LastIndexOf(' ') + 1);
                var regex = new Regex($"(?<=^.{{{pattern[0] - 1}}})({character})|(?<=^.{{{pattern[1] - 1}}})({character})");
                var match = regex.Matches(inputString);
                if (match.Count == 1)
                {
                    counter++;
                }
            }

            return counter.ToString();
        }
    }
}
