﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared.Years
{
    public abstract class Year2023 : DaySolver
    {
        public Year2023(string fileName) : base($"Y2023//"+fileName)
        {
        }

        public abstract string Solution1();
        public abstract string Solution2();

    }
}
