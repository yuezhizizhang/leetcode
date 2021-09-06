using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var solutions = new Solution();
            solutions.ThreeSum(nums);
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
            {
                return result;
            }

            Array.Sort(nums);

            for (var i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                TwoSum(nums, i + 1, -nums[i], result);
            }

            return result;
        }

        private void TwoSum(int[] nums, int start, int target, IList<IList<int>> result)
        {
            var left = start;
            var right = nums.Length - 1;

            while (left < right)
            {
                var curSum = nums[left] + nums[right];
                if (curSum == target)
                {
                    result.Add(new List<int> { -target, nums[left++], nums[right--] });

                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }

                    while (left < right && nums[right] == nums[right + 1])
                    {
                        right--;
                    }
                }
                else if (curSum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        public IList<IList<int>> ThreeSumSlow(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            Array.Sort(nums);

            var numCountMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (numCountMap.ContainsKey(num))
                {
                    numCountMap[num] += 1;
                }
                else
                {
                    numCountMap[num] = 1;
                }
            }

            var result = new HashSet<IList<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                numCountMap[nums[i]] -= 1;
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                
                var remaining = 0 - nums[i];
                var set = new HashSet<int>();
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (set.Contains(nums[j]))
                    {
                        continue;
                    }

                    var key = remaining - nums[j];
                    var count = key == nums[j] ? 1 : 0;
                    if (numCountMap.ContainsKey(key) && numCountMap[key] > count)
                    {
                        var triple = new List<int> { nums[i], nums[j], key };
                        result.Add(triple);

                        set.Add(nums[j]);
                        set.Add(key);
                    }
                }
            }

            return result.ToList();
        }
    }
}
