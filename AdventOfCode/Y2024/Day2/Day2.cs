using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day2
{
    internal class Day2 : Year2024
    {
        public Day2() : base(nameof(Day2)) { }

        public override string Solution1()
        {
            var input = ReadPlainInput();
            var splitted = input.Split("\r\n");
            var count = 0;
            foreach (var item in splitted)
            {
                var split = item.ConvertToIntList(' ');
                var order = (split[0] > split[1]);

                if (order)
                    count += Descend(split) ? 1 : 0;
                else
                    count += Ascend(split) ? 1 : 0;

            }
            return count.ToString();
        }

        private bool Descend(List<int> row)
        {
            for (int i = 0; i < row.Count - 1; i++)
            {
                var num = Math.Abs(row[i] - row[i + 1]);
                if (row[i] <= row[i + 1] || num >= 4)
                {
                    return false;
                }
            }
            return true;
        }
        private bool Ascend(List<int> row)
        {
            for (int i = 0; i < row.Count - 1; i++)
            {
                var num = Math.Abs(row[i] - row[i + 1]);
                if (row[i] >= row[i + 1] || num >= 4)
                {
                    return false;
                }
            }
            return true;
        }

        public override string Solution2()
        {
            var input = ReadPlainInput();
            var splitted = input.Split("\r\n");
            var count = 0;

            foreach (var item in splitted)
            {
                var split = item.ConvertToIntList(' ');
                var order = (split[0] > split[1]);
                var isGood = false;
                if (order)
                    isGood = Descend(split);
                else
                    isGood = Ascend(split);

                if (isGood)
                {
                    count++;
                }
                else
                {
                    for (int i = 0; i < split.Count; i++)
                    {
                        var removed = split[i];
                        split.RemoveAt(i);

                        order = (split[0] > split[1]);

                        if (order)
                            isGood = Descend(split);
                        else
                            isGood = Ascend(split);
                        if (isGood)
                        {
                            count++;
                            break;
                        }
                        split.Insert(i, removed);
                    }
                }
            }
            return count.ToString();
        }
    }
}
