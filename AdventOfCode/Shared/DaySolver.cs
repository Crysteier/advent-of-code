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
        public readonly List<string> test = new List<string>();
        public DaySolver(string folderPath)
        {
            ReadInput(folderPath);
            ReadTests(folderPath);
        }

        public List<string> ReadTests(string folderPath)
        {
            var fullPath = folderPath + $"//test.txt";
            try
            {
                var sr = new StreamReader(fullPath);
                var line = sr.ReadLine();
                while (line is not null)
                {
                    test.Add(line);
                    line = sr.ReadLine();
                }
                return test;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<string> ReadInput(string folderPath)
        {
            var fullPath = folderPath + $"//input.txt";
            try
            {
                var sr = new StreamReader(fullPath);
                var line = sr.ReadLine();
                while (line is not null)
                {
                    input.Add(line);
                    line = sr.ReadLine();
                }
                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
