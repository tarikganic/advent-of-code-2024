using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode.Days
{
    public static class Day04
    {
        public static void Solve()
        {

            var lines = File.ReadAllLines("Assets/inputDay04.txt");

            var grid = new Dictionary<Complex, char>();

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    grid[new Complex(i, j)] = lines[i][j];
                }
            }

            int resultPart1 = 0;

            var directions = new List<Complex> {
                new Complex(1, 0), //down,
                new Complex(-1, 0), //up,
                new Complex(0, 1), //right,
                new Complex(0, -1), //left,
                new Complex(1, 1), //down-right,
                new Complex(1, -1), //down-left,
                new Complex(-1, 1), //up-right,
                new Complex(-1, -1) //up-left
            };


            foreach (var start in grid.Keys)
            {
                foreach (var d in directions)
                {
                    if (grid.TryGetValue(start, out char c1) && c1 == 'X' &&
                        grid.TryGetValue(start + d, out char c2) && c2 == 'M' &&
                        grid.TryGetValue(start + d * 2, out char c3) && c3 == 'A' &&
                        grid.TryGetValue(start + d * 3, out char c4) && c4 == 'S')
                    {
                        resultPart1++;
                    }
                }
            }
            Console.WriteLine(resultPart1);



            int resultPart2 = 0;

            foreach (var start in grid.Keys)
            {
                if (grid.TryGetValue(start, out char mid) && mid == 'A')
                {
                    bool condition1 =
                        (grid.TryGetValue(start - new Complex(1, 1), out char c1a) && c1a == 'M' &&
                        grid.TryGetValue(start + new Complex(1, 1), out char c1b) && c1b == 'S') ||
                        (grid.TryGetValue(start - new Complex(1, 1), out char c2a) && c2a == 'S' &&
                        grid.TryGetValue(start + new Complex(1, 1), out char c2b) && c2b == 'M');

                    bool condition2 =
                        (grid.TryGetValue(start - new Complex(1, -1), out char c3a) && c3a == 'M' &&
                        grid.TryGetValue(start + new Complex(1, -1), out char c3b) && c3b == 'S') ||
                        (grid.TryGetValue(start - new Complex(1, -1), out char c4a) && c4a == 'S' &&
                        grid.TryGetValue(start + new Complex(1, -1), out char c4b) && c4b == 'M');

                    if (condition1 && condition2)
                    {
                        resultPart2++;
                    }
                }
            }
            Console.WriteLine(resultPart2);
        }
    }
}
