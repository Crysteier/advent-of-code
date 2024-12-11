using AdventOfCode.Shared.Years;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Y2024.Day4
{
    public class Day4 : Year2024
    {
        public Day4() : base(nameof(Day4))
        {

        }
        public override string Solution1()
        {
            string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
            string input2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            var sum = 0;
            bool multiply = true;
            foreach (Match match in matches)
            {
                if (match.Groups[0].Value == "don't()")
                {
                    multiply = false;
                }
                else if (match.Groups[0].Value == "do()")
                {
                    multiply = true;
                }
                else if (multiply)
                {
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);
                    sum += num1 * num2;
                }
            }
            return sum.ToString();
        }

        public override string Solution2()
        {
            throw new NotImplementedException();
        }
    }
}
