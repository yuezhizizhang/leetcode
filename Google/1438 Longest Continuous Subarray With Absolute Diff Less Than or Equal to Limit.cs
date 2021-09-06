using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            solution.LongestSubarray(new int[] { 9, 8, 4, 2 }, 5);
        }
    }

    public class Solution
    {
        public int LongestSubarray(int[] nums, int limit)
        {
            if (nums == null || nums.Length < 1 || limit < 0)
            {
                throw new ArgumentException();
            }

            var max = new LinkedList<int>();
            var min = new LinkedList<int>();
            var left = 0;
            var right = 0;
            
            while (right < nums.Length)
            {
                var num = nums[right++];
                while (max.Count > 0 && num > max.Last.Value) max.RemoveLast();
                while (min.Count > 0 && num < min.Last.Value) min.RemoveLast();

                max.AddLast(num);
                min.AddLast(num);

                if (max.First.Value - min.First.Value <= limit) continue;

                num = nums[left++];
                if (max.First.Value == num) max.RemoveFirst();
                if (min.First.Value == num) min.RemoveFirst();
            }

            return right - left;
        }

        public int LongestSubarraySlow(int[] nums, int limit)
        {
            if (nums == null || nums.Length < 1 || limit < 0)
            {
                throw new ArgumentException();
            }

            var minPos = 0;
            var maxPos = 0;

            var start = 0;
            var longest = 1;
            var length = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                var value = nums[i];
                var diffMin = Math.Abs(value - nums[minPos]);
                var diffMax = Math.Abs(value - nums[maxPos]);

                if (diffMin > limit || diffMax > limit)
                {
                    longest = Math.Max(i - start, longest);

                    var pos = -1;
                    if (diffMin > limit)
                        pos = minPos;

                    if (diffMax > limit)
                        pos = Math.Max(pos, maxPos);

                    start = i;
                    minPos = i;
                    maxPos = i;

                    var curr = i;
                    while (--curr > pos)
                    {
                        var diff = Math.Abs(nums[curr] - value);
                        if (diff > limit)
                            break;

                        start = curr;
                        if (nums[curr] < nums[minPos])
                            minPos = curr;
                        else if (nums[curr] > nums[maxPos])
                            maxPos = curr;
                    }

                    length = i - start + 1;
                }
                else
                {
                    length++;

                    if (value < nums[minPos])
                        minPos = i;
                    else if (value > nums[maxPos])
                        maxPos = i;
                }
            }

            return Math.Max(longest, length);
        }
    }
}
