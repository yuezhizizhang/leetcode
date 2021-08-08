using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 1, 1 };
            var solution = new Solution();
            solution.FindMedianSortedArrays(nums1, nums2);
        }
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;
            var median = (int)((totalLength - 1) / 2);
            var isEven = totalLength % 2 == 0;

            var m1 = 0;
            var m2 = 0;
            var p1 = 0;
            var p2 = 0;
            var count = 0;
            while (p1 < nums1.Length && p2 < nums2.Length && count <= median + 1)
            {
                if (nums1[p1] <= nums2[p2])
                {
                    if (count == median)
                    {
                        m1 = nums1[p1];
                    }

                    if (count == median + 1)
                    {
                        m2 = nums1[p1];
                    }

                    p1++;
                } 
                else
                {
                    if (count == median)
                    {
                        m1 = nums2[p2];
                    }

                    if (count == median + 1)
                    {
                        m2 = nums2[p2];
                    }

                    p2++;
                }

                count++;
            }

            var nums = p1 < nums1.Length ? nums1 : nums2;
            var p = p1 < nums1.Length ? p1 : p2;
            if (count <= median)
            {
                var index = p + median - count;
                m1 = nums[index];
            }

            if (isEven && count <= median + 1)
            {
                var index = p + median + 1 - count;
                m2 = nums[index];
            }

            if (isEven)
            {
                return (m1 + m2) / 2.0;
            }
            else
            {
                return m1;
            }
        }
    }


}
