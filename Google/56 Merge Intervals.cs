using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var intervals = new int[4][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var solution = new Solution();
            var result = solution.Merge(intervals);
        }
    }

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            var merged = new List<int[]>();
            foreach (var interval in intervals)
            {
                var last = merged.Count > 0 ? merged.Last() : null;
                if (last != null && interval[0] <= last[1])
                {
                    last[1] = Math.Max(last[1], interval[1]);
                }
                else
                {
                    merged.Add(interval);
                }
            }

            return merged.ToArray();
        }
    }
}
