using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public static class StringExtensions
    {
        public static int ToInt(this string from)
        {
            string stringWithoutSpaces = Regex.Replace(from, @"\s", "");

            if (stringWithoutSpaces.Length <= 0)
            {
                throw new ArgumentException($"Incorrect string to int format: [{from}]");
            }

            try
            {
                if (int.TryParse(stringWithoutSpaces, out int result))
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            throw new ArgumentException("Incorrect string to int format!");
        }

        public static List<int> ConvertToIntList(this string input, char separator)
        {
            return input.Split(separator).Select(int.Parse).ToList();
        }

        public static string ToConsole(this List<int> row)
        {
            var result = "";
            foreach (var item in row)
            {
                result += item + " ";
            }
            return result;
        }

        public static string ToConsole(this int[] row)
        {
            var result = "";
            foreach (var item in row)
            {
                result += item + " ";
            }
            return result;
        }
    }
}
