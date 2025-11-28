using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day01
    {
        public static void Solve()
        {
            var lines = File.ReadAllLines("Assets/inputDay01.txt");
            //foreach(var line in lines)
            //    Console.WriteLine(line);

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            foreach (var line in lines)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                left.Add(int.Parse(parts[0]));
                right.Add(int.Parse(parts[1]));
            }


            int[] leftArr = left.ToArray();
            int[] rightArr = right.ToArray();


            leftArr = leftArr.OrderByDescending(x => x).ToArray();
            rightArr = rightArr.OrderByDescending(x => x).ToArray();


            int result = 0;
            for (int i = 0; i < leftArr.Length; i++)
            {
                result += (int)MathF.Abs(leftArr[i] - rightArr[i]);
            }

            Console.WriteLine("First part: " + result);

            result = 0;
            for (int i = 0; i < leftArr.Length; i++)
            {
                var counter = 0;
                for (int j = 0; j < rightArr.Length; j++)
                {
                    if (leftArr[i] == rightArr[j])
                        counter++;
                }
                if (counter > 0)
                    result += counter * leftArr[i];
                else
                    result += 0;
            }
            Console.WriteLine("Second part: " + result);
        }
    }
}
