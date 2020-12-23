using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Puzzles
{
    public class Puzzle_8 : IPuzzle
    {
        private readonly string[] passportData;
        private readonly Regex pattern;

        public Puzzle_8()
        {
            passportData = Inputs.GetInput("Day4.txt").ToArray();
            pattern = new Regex(@"(\S+:\S+)", RegexOptions.Compiled);
        }

        public string Run()
        {
            int validPassportCount = 0;
            var passportString = new StringBuilder();
            var requiredFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            var validationRules = ValidationRules.Build();
            for (int i = 0; i < passportData.Length; i++)
            {
                if (i < passportData.Length && !string.IsNullOrWhiteSpace(passportData[i]))
                {
                    passportString.Append($" {passportData[i]}");
                }
                else
                {
                    var passportFields = pattern
                        .Matches(passportString.ToString())
                        .Select(m =>
                        new
                        {
                            Key = m.Value.Substring(0, m.Value.IndexOf(':')),
                            Value = m.Value[(m.Value.IndexOf(':') + 1)..]
                        });


                    if (requiredFields.All(x => passportFields.Any(rf => rf.Key == x)) &&
                        passportFields.All(rf =>
                            !validationRules.TryGetValue(rf.Key, out var validationRule)
                            || validationRule(rf.Value)))
                    {
                        validPassportCount++;
                    }

                    passportString.Clear();
                }
            }

            return validPassportCount.ToString();
        }
    }

    public static class ValidationRules
    {
        public static Dictionary<string, Func<string, bool>> Build()
        {
            var eyeColours = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var rules = new Dictionary<string, Func<string, bool>> {
                {"byr", input => input.Length == 4 && int.TryParse(input, out var birthDate) && birthDate >= 1920 && birthDate <= 2002 },
                {"iyr", input => input.Length == 4 && int.TryParse(input, out var issueDate) && issueDate >= 2010 && issueDate <= 2020 },
                {"eyr", input => input.Length == 4 && int.TryParse(input, out var expiryDate) && expiryDate >= 2020 && expiryDate <= 2030 },
                {"hgt", input => {
                    if(int.TryParse(input[0..^2], out var height)){
                        var measurement = input[^2..];
                        if(measurement == "in")
                        {
                            return height >= 59 && height <= 76;
                        }
                        else if(measurement == "cm")
                        {
                            return height >= 150 && height <= 193;
                        }
                    }

                    return false;
                } },
                {"hcl", input => Regex.IsMatch(input, "#[0-9a-f]{6}$") },
                {"ecl", input => eyeColours.Contains(input) },
                {"pid", input => Regex.IsMatch(input, "^[0-9]{9}$") }
            };

            return rules;
        }
    }
}
