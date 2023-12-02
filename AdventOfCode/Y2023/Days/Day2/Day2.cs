using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2023.Days.Day2
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
                var gameNum = line.Substring(0, line.IndexOf(':'));
                var game = line.Substring(line.IndexOf(':') + 2);

                int reds = 0;
                int blues = 0;
                int greens = 0;
                bool falseRound = false;
                var rounds = game.Split(';');

                foreach (var round in rounds)
                {
                    var cubes = round.Split(',', StringSplitOptions.TrimEntries);

                    foreach (var cube in cubes)
                    {
                        var oneCube = cube.Split(' ');

                        switch (oneCube[1])
                        {
                            case "red":
                                reds = int.Parse(oneCube[0]);
                                break;
                            case "blue":
                                blues = int.Parse(oneCube[0]);
                                break;
                            case "green":
                                greens = int.Parse(oneCube[0]);
                                break;
                            default:
                                break;
                        }

                        if (reds > MaxRed || blues > MaxBlue || greens > MaxGreen)
                        {
                            falseRound = true;
                            break;
                        }
                    }
                    if (falseRound)
                    {
                        break;
                    }
                }
                if (falseRound)
                {
                    falseRound = !falseRound;
                    continue;
                }
                sum += int.Parse(gameNum.Split(' ')[1]);
                falseRound = !falseRound;

            }

            return sum.ToString();
        }

        public override string Solution2()
        {
            int sum = 0;

            foreach (var line in input)
            {
                var gameNum = line.Substring(0, line.IndexOf(':'));
                var game = line.Substring(line.IndexOf(':') + 2);

                int reds = 0;
                int blues = 0;
                int greens = 0;
                var rounds = game.Split(';');

                foreach (var round in rounds)
                {
                    var cubes = round.Split(',', StringSplitOptions.TrimEntries);

                    foreach (var cube in cubes)
                    {
                        var oneCube = cube.Split(' ');

                        switch (oneCube[1])
                        {
                            case "red":
                                reds = oneCube[0].ToInt() > reds ? oneCube[0].ToInt() : reds;
                                break;
                            case "blue":
                                blues = oneCube[0].ToInt() > blues ? oneCube[0].ToInt() : blues;
                                break;
                            case "green":
                                greens = oneCube[0].ToInt() > greens ? oneCube[0].ToInt() : greens;
                                break;
                            default:
                                break;
                        }

                    }
                }

                sum += reds * greens * blues;
            }

            return sum.ToString();
        }
    }
}
