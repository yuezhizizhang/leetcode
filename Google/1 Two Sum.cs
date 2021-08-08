using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 7, 11, 15 };
            var result = TwoSum(arr, 9);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var numToIndexMap = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (numToIndexMap.ContainsKey(diff))
                {
                    return new int[] { i, numToIndexMap[diff] };
                }

                if (!numToIndexMap.ContainsKey(nums[i]))
                {
                    numToIndexMap[nums[i]] = i;
                }
            }

            return null;
        }
    }
}
