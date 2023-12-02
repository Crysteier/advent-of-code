using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared.Years
{
    public abstract class Year2022 : DaySolver
    {
        public Year2022(string day) : base($"Y2022//" + day) { }
        public abstract string Solution1();
        public abstract string Solution2();

    }
}
