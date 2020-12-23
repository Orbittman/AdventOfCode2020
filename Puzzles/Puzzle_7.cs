using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_7 : IPuzzle
    {
        private string[] passportData;
        private Regex pattern;

        public Puzzle_7()
        {
            passportData = Inputs.GetInput("Day4.txt").ToArray();
            pattern = new Regex(@"(\S+:\S+)", RegexOptions.Compiled);
        }

        public string Run()
        {
            int validPassportCount = 0;
            var passportString = new StringBuilder();
            var requiredFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            for (int i = 0; i<passportData.Length; i++)
            {
                if (i < passportData.Length && !string.IsNullOrWhiteSpace(passportData[i]))
                {
                    passportString.Append($" {passportData[i]}");
                }
                else
                {
                    var passportFields = pattern
                        .Matches(passportString.ToString())
                        .Select(m => m.Value.Substring(0, m.Value.IndexOf(':')));

                    if(requiredFields.All(x => passportFields.Any(rf => rf == x)))
                    {
                        validPassportCount++;
                    }

                    passportString.Clear();
                }
            }

            return validPassportCount.ToString();
        }
    }
}
