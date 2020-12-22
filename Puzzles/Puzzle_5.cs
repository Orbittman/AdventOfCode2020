using System.Linq;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_5 : IPuzzle
    {
        public string Run()
        {
            var treeLayout = Inputs.GetInput("Puzzle5.txt").Select(x => x.ToCharArray()).ToArray();
            var treeCount = 0;
            var mod = treeLayout[0].Length;
            var x = 0;
            var y = 0;
            for(int i = 1; i < treeLayout.Count(); i++)
            {
                if(treeLayout[i][(i * 3) % mod] == '#')
                {
                    treeCount++;
                }
            }

            return treeCount.ToString();
        }
    }
}
