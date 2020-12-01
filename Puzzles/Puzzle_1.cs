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
                var searchable = input[leftCounter..^0];
                var leftComparison = input[leftCounter];
                while (searchable.Length > 1)
                {
                    var rightComparison = searchable[searchable.Length / 2];
                    if (leftComparison + rightComparison == matchingDate)
                    {
                        return $"{leftComparison * rightComparison}";
                    }

                    searchable = leftComparison + rightComparison < matchingDate ? searchable[(searchable.Length / 2)..^0] : searchable[0..(searchable.Length / 2)];
                }
            }

            return "No result";
        }
    }
}