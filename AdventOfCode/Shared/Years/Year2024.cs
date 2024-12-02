using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared.Years
{
    public abstract class Year2024 : ProblemSolver
    {
        private string _day;
        public Year2024(string day) : base("Y2024", day)
        {
            _day = day;
        }

        public void Solve()
        {
            ReadAllInputs();
            Console.WriteLine($"2024 {_day} Part 1 solution is: " + Solution1());
            Console.WriteLine($"2024 {_day} Part 2 solution is: " + Solution2());
        }
        public abstract string Solution1();
        public abstract string Solution2();
    }
}
