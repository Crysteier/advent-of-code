using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day1
{
    internal class Day2 : Year2024
    {
        public Day2() : base(nameof(Day2)) { }

        public override string Solution1()
        {
            var input = ReadPlainInput(true);
            var splitted = input.Split("\r\n");
            var column1 = new List<int>();
            var column2 = new List<int>();
            //split the input into two columns
            foreach (var item in splitted)
            {
                var split = item.Split(" ");
                column1.Add(int.Parse(split[0]));
                column2.Add(int.Parse(split[3]));
            }
            column1.Sort();
            column2.Sort();
            var distance = 0;
            for (int i = 0; i < column1.Count; i++)
            {
                distance += Math.Abs(column1[i] - column2[i]);
            }
            return distance.ToString();
        }

        public override string Solution2()
        {
            var input = ReadPlainInput();
            var splitted = input.Split("\r\n");
            var column1 = new List<int>();
            var column2 = new List<int>();
            //split the input into two columns
            foreach (var item in splitted)
            {
                var split = item.Split(" ");
                column1.Add(int.Parse(split[0]));
                column2.Add(int.Parse(split[3]));
            }
            column1.Sort();
            column2.Sort();
            var score = 0;
            foreach (var item in column1)
            {
                //select the number count from the column2 by the number from column1
                var count = column2.Count(x => x == item);
                score += item * count;
            }

            return score.ToString();
        }
    }
}
