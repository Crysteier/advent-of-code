using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;
using static System.Reflection.Metadata.BlobBuilder;

namespace AdventOfCode.Y2023.Day2
{
    internal class Day2 : Year2023
    {
        private const int MaxRed = 12;
        private const int MaxGreen = 13;
        private const int MaxBlue = 14;

        private string[] tests = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        public Day2() : base($"{nameof(Day2)}//input2.txt") { }

        public override string Solution1()
        {
            int sum = 0;

            foreach (var line in input)
            {
                var gameNum = GetMaxNumber(line, ("Game (\\d+)")).First();
                var greenMax = GetMaxNumber(line,("(\\d+) green")).Max();
                var blueMax = GetMaxNumber(line, ("(\\d+) blue")).Max();
                var redMax = GetMaxNumber(line, ("(\\d+) red")).Max();

                if (!(greenMax > MaxGreen || blueMax > MaxBlue || redMax > MaxRed))
                {
                    sum += gameNum;
                }
            }

            return sum.ToString();
        }

        public override string Solution2()
        {
            int sum = 0;

            foreach (var line in input)
            {
                var greenMax = GetMaxNumber(line, ("(\\d+) green")).Max();
                var blueMax = GetMaxNumber(line, ("(\\d+) blue")).Max();
                var redMax = GetMaxNumber(line, ("(\\d+) red")).Max();

                sum += greenMax * blueMax * redMax;
            }
            
            return sum.ToString();
        }

        /// <summary>
        /// Pretty much yoinked this from @encse because its so very nice.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="pattern"></param>
        /// <returns>The parsed int number from match.</returns>
        private IEnumerable<int> GetMaxNumber(string game,string pattern)
        {
            var result = from m in Regex.Matches(game, pattern) select int.Parse(m.Groups[1].Value);
            return result;
        }
    }
}
