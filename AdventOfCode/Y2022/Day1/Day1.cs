using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2022.Day1
{
    public class Day1 : Year2022
    {
        public Day1() : base(nameof(Day1)) { }

        public override string Solution1()
        {
            var maxCalories = 0;
            var currentCalories = 0;
            foreach (var line in input)
            {
                if (line == "")
                {
                    maxCalories = currentCalories > maxCalories ? currentCalories : maxCalories;
                    currentCalories = 0;
                    continue;
                }
                currentCalories += line.ToInt();
            }

            return maxCalories.ToString();
        }

        /// <summary>
        /// To be honest, again yoinked this from @encse.
        /// </summary>
        /// <returns></returns>
        public override string Solution2()
        {
            var plainInput = ReadPlainInput();

            var topThree = 
                from elf in plainInput.Split("\r\n\r\n")
                let cal = elf.Split("\r\n").Select(int.Parse).Sum()
                           orderby cal descending
                           select cal;
            return topThree.Take(3).Sum().ToString();
        }
    }
}
