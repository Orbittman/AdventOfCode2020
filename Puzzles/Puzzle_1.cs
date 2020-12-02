namespace AdventOfCode2020.Puzzles
{
    using System;

    public class Puzzle_1 : IPuzzle
    {
        private readonly int matchingDate = 2020;

        public string Run()
        {
            var input = Inputs.ExpensesReport;
            Array.Sort(input);

            for (int leftCounter = 0; leftCounter < input.Length; leftCounter++)
            {
                var range = (leftCounter, input.Length - 1);
                var leftComparison = input[leftCounter];
                while (range.Item2 - range.Item1 > 1)
                {
                    var currentIndex = range.Item1 + (range.Item2 - range.Item1) / 2;
                    var rightComparison = input[currentIndex];
                    var sum = leftComparison + rightComparison;
                    if (sum == matchingDate)
                    {
                        return $"{leftComparison * rightComparison}";
                    }

                    range = sum < matchingDate ? (currentIndex, range.Item2) : (range.Item1, currentIndex);
                }
            }

            return "No result";
        }
    }
}