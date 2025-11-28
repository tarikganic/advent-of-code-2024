using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day02
    {
        private static bool IsSafe(List<int> nums)
        {
            bool inc = true;
            bool dec = true;

            for (int i = 1; i < nums.Count; i++)
            {
                int diff = nums[i] - nums[i - 1];

                // razlika 0 ili >3 ili <-3 → odmah unsafe
                if (diff == 0 || Math.Abs(diff) > 3)
                    return false;

                if (diff < 0)
                    inc = false;

                if (diff > 0)
                    dec = false;
            }

            return inc || dec;
        }
       
        public static void Solve()
        {
            var lines = File.ReadAllLines("Assets/inputDay02.txt");

            int safe = 0;

            foreach (var line in lines)
            {
                var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

                if (IsSafe(nums))
                    safe++;
            }


            Console.WriteLine("Safe: " + safe);
        }
    }
}
