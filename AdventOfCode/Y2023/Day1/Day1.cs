using System.Text.RegularExpressions;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2023.Day1
{
    public class Day1 : Year2023
    {
        string[] test = new[]
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };

        public Day1() : base($"{nameof(Day1)}//input1.txt") { }

        public override string Solution1()
        {
            string numbersOnly = string.Empty;
            var sum = 0;
            foreach (var line in input)
            {
                numbersOnly = Regex.Replace(line, "[^0-9.]", "");
                var number = numbersOnly[0].ToString() + numbersOnly.Last().ToString();
                sum += int.Parse(number);
            }
            return sum.ToString();
        }

        public override string Solution2()
        {
            string pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

            var sum = 0;
            var secondsum = 0;
           

            foreach (var line in input)
            {
                var first = Regex.Match(line, pattern);
                var last = Regex.Match(line, pattern, RegexOptions.RightToLeft);

                var number = WordToDigit(first.ToString()) + WordToDigit(last.ToString());
                sum += int.Parse(number);
            }
            return sum.ToString();
        }

        private string WordToDigit(string word)
        {
            int number;
            switch (word)
            {
                case "one":
                    number = 1;
                    break;
                case "two":
                    number = 2;
                    break;
                case "three":
                    number = 3;
                    break;
                case "four":
                    number = 4;
                    break;
                case "five":
                    number = 5;
                    break;
                case "six":
                    number = 6;
                    break;
                case "seven":
                    number = 7;
                    break;
                case "eight":
                    number = 8;
                    break;
                case "nine":
                    number = 9;
                    break;
                default:
                    return word;
            }
            return number.ToString();
        }
    }
}
