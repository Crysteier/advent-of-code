using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public abstract class DaySolver
    {
        public readonly List<string> input = new List<string>();

        public DaySolver(string fileName)
        {
            ReadInput(fileName);
        }

        public List<string> ReadInput(string fileName)
        {
            var inputNumber = Regex.Match(fileName, (@"\d+"),RegexOptions.RightToLeft).Value;
            var path = fileName + $"//input{inputNumber}.txt";
            var sr = new StreamReader(path);
            var line = sr.ReadLine();
            while (line is not null)
            {
                input.Add(line);
                line = sr.ReadLine();
            }
            return input;
        }
    }
}
