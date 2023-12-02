using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public static class StringExtensions
    {
        public static int ToInt(this string from)
        {
            if (int.TryParse(from, out int result))
            {
                return result;
            }

            throw new ArgumentException("Incorrect string to int format!");
        }
    }
}
