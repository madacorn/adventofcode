using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day4
{
    class Card
    {
        List<List<int>> numbers = new List<List<int>>();
        List<List<bool>> marks = new List<List<bool>>();

        public void AddRow(string s)
        {
            string a = s.Replace("\r", "");
            List<string> c = a.Split(' ').ToList();
            c.RemoveAll(s => s == "");
            numbers.Add(c.Select(x => Int32.Parse(x)).ToList());
            marks.Add(Enumerable.Repeat(false, c.Count).ToList());
        }
        public void MarkNumber(int n)
        {
            for (int i = 0; i < numbers.Count; ++i)
            {
                for (int j = 0; j < numbers[i].Count; ++j)
                {
                    if (n == numbers[i][j])
                    {
                        marks[i][j] = true;
                    }
                }
            }
        }
        public bool HavePrize()
        {
            bool prize;
            // Rows
            for (int i = 0; i < numbers.Count; ++i)
            {
                prize = true;
                for (int j = 0; j < numbers[i].Count; ++j)
                {
                    if (!marks[i][j])
                    {
                        prize = false;
                        break;
                    }
                }
                if (prize) return true;
            }
            //Columns
            for (int i = 0; i < numbers[0].Count; ++i)
            {
                prize = true;
                for (int j = 0; j < numbers.Count; ++j)
                {
                    if (!marks[j][i])
                    {
                        prize = false;
                        break;
                    }
                }
                if (prize)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetRemainingNumbers()
        {
            int value = 0;
            for (int i = 0; i < numbers.Count; ++i)
            {
                for (int j = 0; j < numbers[i].Count; ++j)
                {
                    if (!marks[i][j])
                    {
                        value += numbers[i][j];
                    }
                }
            }
            return value;
        }
    }

    public class Day4Solution1 : AOCLib.ProblemSolver
    {
    
        protected override string Solution(string input)
        {
            List<string> input_string = AOCLib.Helper.ConvertStringInputToStringList(input);
            List<int> balls = input_string[0].Split(',').Select(x => Int32.Parse(x)).ToList();
            List<Card> cards = new List<Card>();
            Card c = new Card();
            for(int i = 2; i < input_string.Count;++i)
            {
                if (i % 6 == 1) continue;
                c.AddRow(input_string[i]);
                if(i%6 ==0)
                {
                    cards.Add(c);
                    c = new Card();
                }
            }
            
            for(int i = 0; i < balls.Count; ++i)
            {
                foreach(Card card in cards)
                {
                    card.MarkNumber(balls[i]);
                    if(card.HavePrize())
                    {
                        return (balls[i] * card.GetRemainingNumbers()).ToString();
                    }
                }
            }
            return "";
        }
    }

    public class Day4Solution2 : AOCLib.ProblemSolver
    {
        protected override string Solution(string input)
        {
            List<string> input_string = AOCLib.Helper.ConvertStringInputToStringList(input);
            List<int> balls = input_string[0].Split(',').Select(x => Int32.Parse(x)).ToList();
            List<Card> cards = new List<Card>();
            Card c = new Card();
            for (int i = 2; i < input_string.Count; ++i)
            {
                if (i % 6 == 1) continue;
                c.AddRow(input_string[i]);
                if (i % 6 == 0)
                {
                    cards.Add(c);
                    c = new Card();
                }
            }

            for (int i = 0; i < balls.Count; ++i)
            {
                var copy_card_list = new List<Card>(cards);
                foreach (Card card in copy_card_list)
                {
                    card.MarkNumber(balls[i]);          
                    if (card.HavePrize())
                    {
                        if (cards.Count == 1)
                        {
                            return (balls[i] * card.GetRemainingNumbers()).ToString();
                        }
                        else
                        {
                            cards.Remove(card);
                        }
                    }
                }
  
            }
            return "";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Day4Solution1 solution1 = new Day4Solution1();
            Day4Solution2 solution2 = new Day4Solution2();
            solution1.Run();
            solution2.Run();
        }
    }
}
