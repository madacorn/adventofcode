using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day6
{
    class LanternFishes
    {
        const int NUMBER_CYCLES = 7;
        const int CYCLES_GROWING = 3;
        long [] fishes = new long[NUMBER_CYCLES+CYCLES_GROWING];
        int cycle = 0;

        public LanternFishes(List<int> input)
        {
            foreach (int fish in input)
            {
                fishes[fish]++;
            }
        }
        
        public void Breed()
        {
            fishes[NUMBER_CYCLES+CYCLES_GROWING-1] = fishes[cycle];
        }

        public void NextCycle()
        {
            int next_cycle = cycle;
            cycle = (cycle + 1) % NUMBER_CYCLES;

            fishes[next_cycle] += fishes[7];
            fishes[7] = fishes[8];
            fishes[8] = fishes[9];
            fishes[9] = 0;
        }
        
        public long NumberFishes()
        {
            long count = 0;
            for (int i = 0; i < fishes.Length; ++i)
            {
                count += fishes[i];
            }
            return count;
        }
    }
    public class Day6Solution1 : AOCLib.ProblemSolver
    {


        protected override string Solution(string input)
        {
            string[] arr = input.Split(',');
            LanternFishes fishes = new LanternFishes(arr.Select(x => Int32.Parse(x)).ToList());

            for (int i = 0; i < 80; ++i)
            {
                fishes.Breed();
                fishes.NextCycle();
            }
            return fishes.NumberFishes().ToString();
        }
    }

    public class Day6Solution2 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            string[] arr = input.Split(',');
            LanternFishes fishes = new LanternFishes(arr.Select(x => Int32.Parse(x)).ToList());

            for (int i = 0; i < 256; ++i)
            {
                fishes.Breed();
                fishes.NextCycle();
            }
            return fishes.NumberFishes().ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day6Solution1 solution1 = new Day6Solution1();
            Day6Solution2 solution2 = new Day6Solution2();
            solution1.Run();
            solution2.Run();
        }
    }
}
