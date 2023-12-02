namespace AdventOfCode.Shared.Years
{
    public abstract class Year2022 : ProblemSolver
    {
        private string _day;

        public Year2022(string day) : base("Y2022", day)
        {
            _day = day;
        }

        public void Solve()
        {
            ReadAllInputs();
            Console.WriteLine($"2022 {_day} Part 1 solution is: " + Solution1());
            Console.WriteLine($"2022 {_day} Part 2 solution is: " + Solution2());
        }
        public abstract string Solution1();
        public abstract string Solution2();

    }
}
