using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            solution.Insert(new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } }, new int[] { 2, 5 });
        }
    }

    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            // Sort intervals by start value.
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            var merged = new List<int[]>();
            var start = newInterval[0];
            var end = newInterval[1];
            int i;
            for (i = 0; i < intervals.Length; i++)
            {
                // Stop loop while the new interval start is less than end.
                if (start <= intervals[i][1]) break;

                merged.Add(intervals[i]);
            }

            // If the new interval is greater than any existing ones.
            if (i >= intervals.Length)
            {
                merged.Add(newInterval);
                return merged.ToArray();
            }
            
            // If the new interval is less than any existing ones.
            if (end < intervals[i][0])
            {
                merged.Add(newInterval);
                merged.AddRange(intervals.Skip(i).Take(intervals.Length - i));
                return merged.ToArray();
            }

            start = Math.Min(start, intervals[i][0]);
            if (end <= intervals[i][1])
            {
                // If the new interval end is less than end.
                merged.Add(new int[] { start, intervals[i][1] });
                merged.AddRange(intervals.Skip(i + 1).Take(intervals.Length - i - 1));
                return merged.ToArray();
            }

            for (i = i + 1; i < intervals.Length; i++)
            {
                // Stop loop while the new interval end is less than start.
                if (end < intervals[i][0]) break;
            }

            end = Math.Max(end, intervals[i - 1][1]);
            merged.Add(new int[] { start, end });

            if (i < intervals.Length)
            {
                merged.AddRange(intervals.Skip(i).Take(intervals.Length - i));
            }
            return merged.ToArray();
        }
    }
}
