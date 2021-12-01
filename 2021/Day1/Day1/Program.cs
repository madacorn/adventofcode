using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public class Day1Solution1 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            List<int> num_inputs = AOCLib.Helper.ConvertStringInputToIntList(input);
            int count = 0;
            int previous = num_inputs[0];
            foreach (int current in num_inputs.Skip(1))
            {
                if (previous < current) count++;
                previous = current;
            }

            return count.ToString();
        }
    }

    public class Day1Solution2 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            List<int> num_inputs = AOCLib.Helper.ConvertStringInputToIntList(input);
            int count = 0;
            int sum = num_inputs[0] + num_inputs[1] + num_inputs[2];
            Queue<int> q = new Queue<int>();
            q.Enqueue(num_inputs[0]);
            q.Enqueue(num_inputs[1]);
            q.Enqueue(num_inputs[2]);
            foreach (int current in num_inputs.Skip(3))
            {
                int oldSum= sum;
                sum += (current - q.Dequeue());
                if (oldSum < sum) count++;
                q.Enqueue(current);
            }

            return count.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day1Solution1 solution1 = new Day1Solution1();
            Day1Solution2 solution2 = new Day1Solution2();
            solution1.Run();
            solution2.Run();
        }
    }
}
