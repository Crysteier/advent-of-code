using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2023.Day3
{
    public class Day3 : Year2023
    {
        private int Sum { get; set; } = 0;
        private int NumLen { get; set; } = 0;
        public Day3() : base(nameof(Day3))
        {
        }

        public override string Solution1()
        {
            var plainInput = ReadPlainInput();
            var map = plainInput.Split("\r\n");
            int skipLen = 0;

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] <= '9' && map[i][j] > '0')
                    {
                        CheckAround(ref map, i, j);
                        j += NumLen - 1;
                    }
                }
            }

            return Sum.ToString();
        }

        private void CheckAround(ref string[] map, int i, int j)
        {
            int numlen = 0;
            string number = string.Empty;
            for (int k = j; k < j + 10; k++)
            {
                if (k >= map[i].Length)
                {
                    break;
                }
                if (map[i][k] <= '9' && map[i][k] >= '0')
                {
                    numlen++;
                    number += map[i][k];
                }
                else
                {
                    break;
                }
            }
            NumLen = numlen;
            var intnum = number.ToInt();
            if (
                LeftToRight(ref map, i - 1, j - 1, numlen) ||
                LeftToRight(ref map, i, j - 1, numlen) ||
                LeftToRight(ref map, i + 1, j - 1, numlen)
                )
            {
                var line = map[i].ToCharArray();
                for (int k = j; k <= j + numlen - 1; k++)
                {
                    line[k] = '.';
                }

                map[i] = new string(line);
                Sum += intnum;
            }
        }

        private bool LeftToRight(ref string[] map, int i, int j, int numlen)
        {
            if (i < 0)
            {
                i = 0;
            }

            if (i >= map.Length)
            {
                i = map.Length - 1;
            }

            if (j < 0)
            {
                j = 0;
            }

            for (int k = j; k <= numlen + j + 1; k++)
            {
                if (k >= map[i].Length)
                {
                    return false;
                }


                if (map[i][k] != '.' && (map[i][k] < '0' || map[i][k] > '9'))
                {
                    return true;
                }
            }

            return false;
        }

        public override string Solution2()
        {
            return "";
        }
    }
}
