using System;
using System.Linq;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_2 : IPuzzle
    {
        private readonly int matchingDate = 2020;

        public string Run()
        {
            var input = Inputs.ExpensesReport;
            var counter = 0;

            Array.Sort(input);

            var filteredList = input.Where(i => input[0] + input[1] + i <= matchingDate).ToArray();

            for (int outerCounter = 0; outerCounter < filteredList.Length; outerCounter++)
            {
                for (var innerCounter = outerCounter + 1; innerCounter < filteredList.Length; innerCounter++)
                {
                    var leftComparison = filteredList[outerCounter] + filteredList[innerCounter];

                    var range = (outerCounter, innerCounter:input.Length - 1);
                    while (range.innerCounter - range.outerCounter > 1)
                    {
                        counter++;
                        var currentIndex = range.outerCounter + (range.innerCounter - range.outerCounter) / 2;
                        var rightComparison = input[currentIndex];
                        var sum = leftComparison + rightComparison;
                        if (sum == matchingDate)
                        {
                            return $"{filteredList[outerCounter] * filteredList[innerCounter] * rightComparison} ({filteredList[outerCounter]} * {filteredList[innerCounter]} * {rightComparison}) {counter} iterations";
                        }

                        range = sum < matchingDate ? (currentIndex, range.innerCounter) : (range.outerCounter, currentIndex);
                    }
                }
            }

            return "No result";
        }
    }
}
