using AdventOfCode.Shared.Years;
using System.Text.RegularExpressions;
using AdventOfCode.Shared;

namespace AdventOfCode.Y2023.Day4
{
    public class Day4 : Year2023
    {
        public Day4() : base(nameof(Day4))
        {
        }

        public override string Solution1()
        {
            int sum = 0;
            foreach (var line in input)
            {
                if (line == "") { continue; }
                var numbers = line.Split(new char[] { ':', '|' });
                var winningNumbers = GetNumbers(numbers[1], (@"\b\d+\b")).ToList();
                var myNumbers = GetNumbers(numbers[2], (@"\b\d+\b")).ToList();
                var score = GetCardScore(winningNumbers, myNumbers);
                sum += score;
            }
            return sum.ToString();
        }



        public override string Solution2()
        {
            return "";
        }
        private int GetCardScore(List<int> winningNumbers, List<int> myNumbers)
        {
            return (int)Math.Pow(2, myNumbers.Intersect(winningNumbers).ToList().Count - 1);
        }

        private List<int> GetNumbers(string game, string pattern)
        {
            var result = Regex.Matches(game, pattern);
            var numbers = new List<int>();
            foreach (Match match in result)
            {
                numbers.Add(match.Value.ToInt());
            }
            return numbers;
        }
    }
}
