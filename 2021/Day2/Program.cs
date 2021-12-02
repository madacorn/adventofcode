using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day2
{
    public class Day2Solution1 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            List<string> num_inputs = AOCLib.Helper.ConvertStringInputToStringList(input);
            Vector2 position = new Vector2(0, 0);
            Dictionary<String, Action<int>> actions = new Dictionary<string, Action<int>>()
            {
                { "forward", (x) =>{ position.X += x; }  },
                { "down", (x) =>{ position.Y += x; }  },
                { "up", (x) =>{ position.Y -= x; }  }
            };
            num_inputs.ForEach((s) =>
            {
                string[] action = s.Split(' ');
                actions[action[0]](Int32.Parse(action[1]));
            });
            return (position.X * position.Y).ToString();
        }
    }

    public class Day2Solution2 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            List<string> num_inputs = AOCLib.Helper.ConvertStringInputToStringList(input);
            Vector3 position = new Vector3(0, 0, 0);
            Dictionary<String, Action<int>> actions = new Dictionary<string, Action<int>>()
            {
                { "down", (x) =>{ position.Z += x; }  },
                { "up", (x) =>{ position.Z -= x; }  },
                { "forward", (x) =>
                    {
                        position.X += x;
                        position.Y += x*position.Z;
                    }
                }
            };
            num_inputs.ForEach((s) =>
            {
                string[] action = s.Split(' ');
                actions[action[0]](Int32.Parse(action[1]));
            });
            long solution = (long)(position.X * position.Y);
            return solution.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day2Solution1 solution1 = new Day2Solution1();
            Day2Solution2 solution2 = new Day2Solution2();
            solution1.Run();
            solution2.Run();
        }
    }
}
