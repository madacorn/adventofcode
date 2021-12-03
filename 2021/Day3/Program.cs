using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day3
{
    public class Day3Solution1 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            List<string> string_input = AOCLib.Helper.ConvertStringInputToStringList(input);
            int[] values = new int[string_input[0].Length-1];
            string_input.ForEach((s) =>
            {
                for (int counter = 0; counter < values.Length; counter++)
                {
                    values[counter] += (s[counter] == '0') ? 1 : -1;
                }
            });
            int epsilon = 0;
            int gamma = epsilon;
            for (int counter = 0; counter < values.Length; counter++)
            {
                epsilon |= ((values[counter] > 0) ? 0 : 1) << (values.Length-1 - counter);
                gamma |= ((values[counter] > 0) ? 1 : 0) <<  (values.Length-1-counter);
            }
            return (gamma*epsilon).ToString();
        }
    }

    public class Day3Solution2 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {

            List<string> string_input = AOCLib.Helper.ConvertStringInputToStringList(input);        
            int oxigen = 0;
            int bit = 0;

            List<string> oxigen_values = new List<string>(string_input);
            for (int counter = 0; counter < string_input[0].Length - 1; counter++)
            {
                bit = 0;
                oxigen_values.ForEach((s) => {
                    bit += (s[counter] == '0') ? 1 : -1;
                });

                char c = (bit > 0) ? '0' : '1';

                oxigen_values.RemoveAll(s => s[counter] != c);
                if (oxigen_values.Count == 1)
                {
                    break;
                }
            }

            int co2 = 0;
            List<string> co2_values = new List<string>(string_input);
            for (int counter = 0; counter < string_input[0].Length - 1; counter++)
            {
                bit = 0;
                co2_values.ForEach((s) =>
                {
                    bit += (s[counter] == '0') ? 1 : -1;
                });

                char c = (bit <= 0) ? '0' : '1';

                co2_values.RemoveAll(s => s[counter] != c);
                if (co2_values.Count == 1)
                {
                    break;
                }
            }

            for (int counter = 0; counter < string_input[0].Length - 1; counter++)
            {
                oxigen |= ((oxigen_values[0][counter] == '0') ? 0 : 1) << (string_input[0].Length - 2 - counter);
                co2 |= ((co2_values[0][counter] == '0') ? 0 : 1) << (string_input[0].Length - 2 - counter);
            }

            return (oxigen * co2).ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day3Solution1 solution1 = new Day3Solution1();
            Day3Solution2 solution2 = new Day3Solution2();
            solution1.Run();
            solution2.Run();
        }
    }
}
