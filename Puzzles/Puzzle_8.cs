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
        private readonly Dictionary<string, Func<string, bool>> validationRules;
        private readonly string[] requiredFields;
        private readonly IList<Dictionary<string, string>> parsedInput;

        public Puzzle_8()
        {
            passportData = Inputs.GetInput("Day4.txt").ToArray();
            pattern = new Regex(@"(\S+:\S+)", RegexOptions.Compiled);
            validationRules = ValidationRules.Build();
            requiredFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            parsedInput = ParseInput(passportData);
        }

        private IList<Dictionary<string, string>> ParseInput(string[] input)
        {
            var returnValue = new List<Dictionary<string, string>>();
            var passportString = new StringBuilder();
            for (int i = 0; i < passportData.Length; i++)
            {
                if (i < passportData.Length && !string.IsNullOrWhiteSpace(passportData[i]))
                {
                    passportString.Append($" {passportData[i]}");
                }
                else
                {
                    returnValue.Add(pattern
                        .Matches(passportString.ToString())
                        .Select(x => x.Value)
                        .ToDictionary(
                            Key => Key.Substring(0, Key.IndexOf(':')),
                            Value => Value[(Value.IndexOf(':') + 1)..]
                        ));

                    passportString.Clear();
                }
            }

            return returnValue;
        }

        public string Run()
        {
            int validPassportCount = 0;
            var passportString = new StringBuilder();
            for (int i = 0; i < parsedInput.Count; i++)
            {
                if (requiredFields.All(x => parsedInput[i].ContainsKey(x)) &&
                      parsedInput[i].All(rf =>
                          !validationRules.TryGetValue(rf.Key, out var validationRule)
                          || validationRule(rf.Value)))
                {
                    validPassportCount++;
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
