using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var sr = new StreamReader(fileName);
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
