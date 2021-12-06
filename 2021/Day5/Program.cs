using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day5
{    struct Positions
    {
        public int from_x;
        public int from_y;
        public int to_x;
        public int to_y;
    }
    public class Day5Solution1 : AOCLib.ProblemSolver
    {
    

        protected override string Solution(string input)
        {
            List<string> vectors_string = input.Replace(" -> ", ",").Split("\r\n").ToList();
            int max_x = 1;
            int max_y = 1;
            List<Positions> vector_positions = new List<Positions>();
            vectors_string.ForEach(s =>
            {
                List<int> pos_int = s.Split(',').Select(x => Int32.Parse(x)).ToList();
                vector_positions.Add(new Positions
                {
                    from_x = pos_int[0],
                    from_y = pos_int[1],
                    to_x = pos_int[2],
                    to_y = pos_int[3]
                });
            });
            foreach (Positions p in vector_positions)
            {
                if (p.from_x > max_x) max_x = p.from_x;
                if (p.to_x > max_x) max_x = p.to_x;
                if (p.from_y > max_y) max_y = p.from_y;
                if (p.to_y > max_y) max_y = p.to_y;
            }
            int[,] map = new int[max_x + 1, max_y + 1];

            foreach (Positions p in vector_positions)
            {
                int min_x = Math.Min(p.from_x, p.to_x);
                int min_y = Math.Min(p.from_y, p.to_y);
                max_x = Math.Max(p.from_x, p.to_x);
                max_y = Math.Max(p.from_y, p.to_y);

                if (min_x == max_x)
                {
                    for (int y = min_y; y <= max_y; ++y)
                    {
                        map[min_x, y]++;
                    }
                }
                else if (min_y == max_y)
                {
                    for (int x = min_x; x <= max_x; ++x)
                    {
                        map[x, min_y]++;
                    }
                }
            }
            int count = 0;

            foreach (int i in map)
            {
                if (i > 1) count++;

            }
            return count.ToString();
        }
    }

    public class Day5Solution2 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {

            List<string> vectors_string = input.Replace(" -> ", ",").Split("\r\n").ToList();
            int max_x = 1;
            int max_y = 1;
            List<Positions> vector_positions = new List<Positions>();
            vectors_string.ForEach(s =>
            {
                List<int> pos_int = s.Split(',').Select(x => Int32.Parse(x)).ToList();
                vector_positions.Add(new Positions
                {
                    from_x = pos_int[0],
                    from_y = pos_int[1],
                    to_x = pos_int[2],
                    to_y = pos_int[3]
                });
            });
            foreach (Positions p in vector_positions)
            {
                if (p.from_x > max_x) max_x = p.from_x;
                if (p.to_x > max_x) max_x = p.to_x;
                if (p.from_y > max_y) max_y = p.from_y;
                if (p.to_y > max_y) max_y = p.to_y;
            }
            int[,] map = new int[max_x + 1, max_y + 1];

            foreach (Positions p in vector_positions)
            {
                int min_x = Math.Min(p.from_x, p.to_x);
                int min_y = Math.Min(p.from_y, p.to_y);
                max_x = Math.Max(p.from_x, p.to_x);
                max_y = Math.Max(p.from_y, p.to_y);

                if (min_x == max_x)
                {
                    for (int y = min_y; y <= max_y; ++y)
                    {
                        map[min_x, y]++;
                    }
                }
                else if (min_y == max_y)
                {
                    for (int x = min_x; x <= max_x; ++x)
                    {
                        map[x, min_y]++;
                    }
                }
                else
                {
                    int x_inc = (min_x == p.from_x) ? 1 : -1;
                    int y_inc = (min_y == p.from_y) ? 1 : -1;
                    for (int increment = 0; increment <= (max_x- min_x) ; ++increment)
                    {
                        map[p.from_x+increment*x_inc, p.from_y+increment*y_inc]++;
                    }
                }
            }
            int count = 0;

            foreach (int i in map)
            {
                if (i > 1) count++;

            }
            return count.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day5Solution1 solution1 = new Day5Solution1();
            Day5Solution2 solution2 = new Day5Solution2();
            solution1.Run();
            solution2.Run();
        }
    }
}
