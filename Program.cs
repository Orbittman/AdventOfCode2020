namespace AdventOfCode2020
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AdventOfCode2020.Puzzles;

    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = new Puzzle_5();
            var output = string.Empty;
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                output = puzzle.Run();
            }

            timer.Stop();
            Console.WriteLine($"{output} took {timer.ElapsedMilliseconds}");
            Console.ReadKey();
        }
    }
}
