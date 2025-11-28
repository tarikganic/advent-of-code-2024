using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day03
    {
        public static void Solve()
        {
            string input = System.IO.File.ReadAllText("Assets/inputDay03.txt");
            
            var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");

            var partOneFinalScore = 0;

            foreach (Match m in matches)
            {

                int x = int.Parse(m.Groups[1].Value);
                int y = int.Parse(m.Groups[2].Value);
                
                partOneFinalScore += x * y;
            }

            Console.WriteLine("First part: " + partOneFinalScore);
        }

        public static void SolvePart2()
        {
            string input = System.IO.File.ReadAllText("Assets/inputDay03.txt");

            var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");



            int result = 0;

            foreach (Match m in matches)
            {

                int x = int.Parse(m.Groups[1].Value);
                int y = int.Parse(m.Groups[2].Value);

                int mulIndex = m.Index;
                string beforeMul = input.Substring(0, mulIndex);

                bool allowed = false;

                int lastDo = beforeMul.LastIndexOf("do()");
                int lastDont = beforeMul.LastIndexOf("don't()");

                if (lastDo > lastDont || (lastDo == -1 && lastDont == -1))
                {
                    allowed = true;
                }

                if (allowed)
                {
                    result += x * y;
                }

            }

            Console.WriteLine("Second part: " + result);
        }

    }
}
