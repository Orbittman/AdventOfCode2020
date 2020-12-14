namespace AdventOfCode2020
{
    using System;
    using System.Diagnostics;
    using AdventOfCode2020.Puzzles;

    class Program
    {
        static void Main(string[] args)
        {
            var output = string.Empty;
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < 1; i++)
            {
                output = new Puzzle_4().Run();
            }

            timer.Stop();
            Console.WriteLine($"{output} took {timer.ElapsedMilliseconds}");
            Console.ReadKey();
        }
    }
}
