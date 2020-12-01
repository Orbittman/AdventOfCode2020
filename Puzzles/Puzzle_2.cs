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

            // sort the input
            Array.Sort(input);

            // remove any items that are outside the calculable range
            var filteredList = input.Where(i => input[0] + input[1] + i <= matchingDate).ToArray();

            for (int outerCounter = 0; outerCounter < filteredList.Length; outerCounter++)
            {
                for (var innerCounter = outerCounter + 1; innerCounter < filteredList.Length; innerCounter++)
                {
                    var leftComparison = filteredList[outerCounter] + filteredList[innerCounter];

                    // set the strting slice to be the upper group above the right comparison or below
                    var searchable = leftComparison + filteredList[innerCounter] < matchingDate ? filteredList[(innerCounter + 1)..^0] : filteredList[(outerCounter+1)..(innerCounter - 1)];

                    while (searchable.Length > 1)
                    {
                        counter++;
                        var rightComparison = searchable[searchable.Length / 2];
                        if (leftComparison + rightComparison == matchingDate)
                        {
                            return $"{filteredList[outerCounter] * filteredList[innerCounter] * rightComparison} ({filteredList[outerCounter]} * {filteredList[innerCounter]} * {rightComparison}) {counter} iterations";
                        }

                        searchable = leftComparison + rightComparison < matchingDate ? searchable[(searchable.Length / 2)..^0] : searchable[0..(searchable.Length / 2)];
                    }
                }               
            }

            return "No result";
        }
    }
}
