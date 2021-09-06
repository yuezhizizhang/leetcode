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
            var heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var solution = new Solution();
            solution.Trap(heights);
        }
    }

    public class Solution
    {
        public int Trap(int[] height)
        {
            var size = height.Length;
            if (size <= 2)
            {
                return 0;
            }

            var leftMax = new int[size];
            leftMax[0] = height[0];
            var rightMax = new int[size];
            rightMax[size - 1] = height[size - 1];

            for (var i = 1; i < size; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
                rightMax[size - i - 1] = Math.Max(rightMax[size - i], height[size - i - 1]);
            }

            var totalWater = 0;
            for (var i = 1; i < size - 1; i++)
            {
                totalWater += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }

            return totalWater;
        }

        public int TrapSlow(int[] height)
        {
            var maxHeight = height.Max();
            var rows = new int[maxHeight];
            Array.Fill(rows, -1);

            var sum = 0;
            for (var i = 0; i < height.Length; i++)
            {
                var value = height[i];
                for (var j = 0; j < value; j++)
                {
                    if (rows[j] != -1)
                    {
                        sum += i - rows[j] - 1;
                    }

                    rows[j] = i;
                }
            }

            return sum;
        }
    }


}
