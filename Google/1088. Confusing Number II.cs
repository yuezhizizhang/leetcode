using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.ConfusingNumberII(20);
        }
    }

    public class Solution
    {
        private readonly IDictionary<int, int> RotateTable = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 1 },
            { 6, 9 },
            { 8, 8 },
            { 9, 6 },
        };

        public int ConfusingNumberII(int n)
        {
            if (n < 6) return 0;
            if (n < 9) return 1;
            if (n < 10) return 2;

            var total = 2;
            var multiply = 10;
            var rotatableDigits = new int[] { 1, 6, 8, 9 };
            var nums = new List<int> { 0, 1, 6, 8, 9 };

            while (true)
            {
                var count = nums.Count;
                foreach (var d in rotatableDigits)
                {
                    var value = multiply * d;
                    for (var i = 0; i < count; i++)
                    {
                        var sum = value + nums[i];
                        if (sum > n) return total;

                        nums.Add(sum);
                        if (isConfusing(sum)) total++;
                    }
                }
                multiply *= 10;
            }
        }

        public bool isConfusing(int n)
        {
            var old = n;
            var digits = new List<int>();
            while (n > 0)
            {
                digits.Add(n % 10);
                n /= 10;
            }

            var sum = 0;
            foreach (var d in digits)
            {
                sum *= 10;
                sum += RotateTable[d];                                                                                                                                                                                                                                                                         
            }

            return sum != old;
        }
    }
}
