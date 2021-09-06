using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 3 };
            var solution = new Solution();
            solution.SubarraySum(nums, 3);
        }
    }

    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            var sums = new Dictionary<int, int> { { 0, 1 } };

            var total = 0;
            var count = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                total += nums[i];

                var key = total - k;
                if (sums.ContainsKey(key))
                {
                    count += sums[key];
                }

                sums[total] = sums.GetValueOrDefault(total, 0) + 1;
            }

            return count;
        }

        public int SubarraySumONSquare(int[] nums, int k)
        {
            if (nums == null || nums.Length < 1)
            {
                return 0;
            }

            var sums = new int[nums.Length];
            var total = 0;
            var count = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                total += nums[i];
                sums[i] = total;

                if (sums[i] == k)
                {
                    count++;
                }
            }

            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (sums[j] - sums[i] == k)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
