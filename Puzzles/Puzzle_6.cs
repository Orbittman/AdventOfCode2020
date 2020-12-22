using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_6 : IPuzzle
    {
        private char[][] treeLayout;

        public Puzzle_6()
        {
            treeLayout = Inputs.GetInput("Puzzle5.txt").Select(x => x.ToCharArray()).ToArray();
        }

        public string Run()
        {
            var inputs = new[] {
                new[] { 1, 1 },
                new[] { 3, 1 },
                new[] { 5, 1 },
                new[] { 7, 1 },
                new[] { 1, 2 }
            };

            var mod = treeLayout[0].Length;
            long result = 0;
            foreach(var route in inputs)
            {
                var collisions = TreeCollisions(treeLayout, mod, route[0], route[1]);
                result = result == 0 ? collisions : result * collisions;
            }

            return result.ToString();
        }

        private int TreeCollisions(char[][] treeLayout, int mod, int x, int y)
        {
            var treeCount = 0;
            var modCounter = 1;
            for (int i = y; i < treeLayout.Length; i+=y)
            {
                if (treeLayout[i][modCounter++ * x % mod] == '#')
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}
