using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public bool IsPossibleDivide(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || nums.Length % k != 0) return false;

            var counter = new Dictionary<int, int>();
            foreach(var num in nums)
            {
                if (counter.ContainsKey(num)) counter[num]++;
                else counter.Add(num, 1);
            }

            var keys = counter.Keys.OrderBy(n => n);
            foreach (var num in keys)
            {
                if (counter[num] <= 0) continue;

                var count = counter[num];
                for (var i = 1; i < k; i++)
                {
                    var next = num + i;
                    if (!counter.ContainsKey(next) || counter[next] < count) return false;

                    counter[next] -= count;
                }
            }

            return true;
        }
    }
}
