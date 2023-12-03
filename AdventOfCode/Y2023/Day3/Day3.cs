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
        private Dictionary<string, List<int>> stars = new Dictionary<string, List<int>>();
        private string currentCoords = string.Empty;

        /// <summary>
        /// I dont give a fuck that this is so fucking ugly, I LOVE IT.
        /// </summary>
        public Day3() : base(nameof(Day3))
        {
        }

        #region Solution 1

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
                LeftToRightForNumber(ref map, i - 1, j - 1, numlen) ||
                LeftToRightForNumber(ref map, i, j - 1, numlen) ||
                LeftToRightForNumber(ref map, i + 1, j - 1, numlen)
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

        private bool LeftToRightForNumber(ref string[] map, int i, int j, int numlen)
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


        #endregion

        public override string Solution2()
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
                        CheckAround2(ref map, i, j);
                        j += NumLen - 1;
                    }
                }
            }

            Sum = 0;
            var listValues = stars.Where(kv => kv.Value.Count >= 2)
                .Select(kv => kv.Value).ToList();
            var listResultValues = new List<int>();
            foreach (var values in listValues)
            {
                int multiplied = 1;
                foreach (var value in values)
                {
                    multiplied *= value;
                }
                listResultValues.Add(multiplied);
            }

            Sum = listResultValues.Sum();
            return Sum.ToString();
        }

        private void CheckAround2(ref string[] map, int i, int j)
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
                LeftToRightForNumber2(ref map, i - 1, j - 1, numlen) ||
                LeftToRightForNumber2(ref map, i, j - 1, numlen) ||
                LeftToRightForNumber2(ref map, i + 1, j - 1, numlen)
                )
            {
                if (stars.ContainsKey(currentCoords))
                {
                    stars[currentCoords].Add(number.ToInt());
                }
                else
                {
                    stars.Add(currentCoords, new List<int>() { number.ToInt() });
                }

                var line = map[i].ToCharArray();
                for (int k = j; k <= j + numlen - 1; k++)
                {
                    line[k] = '.';
                }

                map[i] = new string(line);
            }
        }

        private bool LeftToRightForNumber2(ref string[] map, int i, int j, int numlen)
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

                if (map[i][k] == '*' && map[i][k] != '.' && (map[i][k] < '0' || map[i][k] > '9'))
                {
                    currentCoords = i + "," + k;
                    return true;
                }
            }

            return false;
        }

    }
}
