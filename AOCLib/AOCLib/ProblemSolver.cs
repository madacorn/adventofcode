using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOCLib
{
    public abstract class ProblemSolver
    {
        public const string INPUT_FILE = "input.txt";
        public const string OUTPUT_FILE = "output.txt";

        public void Run()
        {
            string input = File.ReadAllText(INPUT_FILE);

            string result = Solution(input);
            
            File.WriteAllText(this.GetType().Name+OUTPUT_FILE, result);
        }

        protected abstract string Solution(string input);
        
    }
    public static class Helper
    {
        public static List<int> ConvertStringInputToIntList(string s)
        {
            string[] arr = s.Split('\n');
            return arr.Select(x => Int32.Parse(x)).ToList();
        }
    }
}
