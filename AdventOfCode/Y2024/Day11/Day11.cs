using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day11
{
    public class Day11 : Year2024
    {
        public Day11() : base(nameof(Day11))
        {

        }
        public override string Solution1()
        {
            var input = ReadPlainInput().Split(" ").ToList();
            var count = 0;
            var a = 1;
            foreach (var stone in input)
            {
                Console.WriteLine(a);
                count += Calculate(stone);
                a++;
            }
            return count.ToString();
        }

        private int Calculate(string stone)
        {
            var res = new List<string>() { stone };

            for (int i = 0; i < 75; i++)
            {
                Console.WriteLine(i);
                res = Calc(res);
            }

            return res.Count;
        }

        private List<string> Calc(List<string> input)
        {
            var res = new List<string>();
            foreach (var item in input)
            {
                if (item == "0")
                {
                    res.Add("1");
                }
                else if (item.Length % 2 == 0)
                {
                    ulong half = ulong.Parse(item.Substring(0, item.Length / 2));
                    ulong secondHalf = ulong.Parse(item.Substring(item.Length / 2));
                    res.Add(half.ToString());
                    res.Add(secondHalf.ToString());
                }
                else
                {
                    res.Add((ulong.Parse(item) * 2024).ToString());
                }
            }
            return res;
        }

        public override string Solution2()
        {
            var stones = new List<string>();
            var input = ReadPlainInput().Split(" ");
            for (var i = 0; i < 1; i++)
            {
                //Calculate();
            }
            return stones.Count.ToString();
        }
    }
}
