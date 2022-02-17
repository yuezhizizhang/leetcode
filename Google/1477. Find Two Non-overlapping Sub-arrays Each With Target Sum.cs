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
            solution.MinSumOfLengths(new int[] { 3, 2, 2, 4, 3 }, 3);
        }
    }

    public class Solution
    {
        public int MinSumOfLengths(int[] arr, int target)
        {
            if (arr == null || arr.Length < 2) return -1;

            var minLengths = new int[2];
            Array.Fill(minLengths, -1);

            var size = arr.Length;
            var start = 0;
            var end = 0;
            var sum = 0;
            var windows = new Dictionary<int, Window>();
            while (end < size)
            {
                sum += arr[end++];

                if (sum > target)
                {
                    do
                    {
                        sum -= arr[start++];
                    } while (sum > target);
                }

                if (sum == target)
                {
                    windows.Add(start, new Window(start, end));
                    sum -= arr[start++];
                }
            }

            var next = new int[size];
            next[size - 1] = 0;
            for (var i = next.Length - 1; i >= 0; i--)
            {
                if (i + 1 < next.Length) next[i] = next[i + 1];

                if (windows.ContainsKey(i))
                {
                    var len = windows[i].Length;
                    if (next[i] <= 0 || len < next[i]) next[i] = len;
                }
            }

            var minLength = -1;
            foreach (var w in windows.Values)
            {
                if (w.End < size && next[w.End] > 0)
                {
                    var totalLength = w.Length + next[w.End];
                    if (minLength < 0 || totalLength < minLength) minLength = totalLength;
                }
            }


            return minLength;
        }

        class Window
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Length { get; private set; }

            public Window(int start, int end)
            {
                this.Start = start;
                this.End = end;
                this.Length = this.End - this.Start;
            }
        }
    }
}
