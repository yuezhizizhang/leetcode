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
            var isEven = totalLength % 2 == 0;
            
            var size = isEven ? totalLength / 2 + 1: (totalLength + 1) / 2;
            var merged = new int[size];

            var p1 = 0;
            var p2 = 0;
            for (var i = 0; i < merged.Length; i++)
            {
                if (p1 < nums1.Length && p2 < nums2.Length)
                {
                    if (nums1[p1] <= nums2[p2])
                    {
                        merged[i] = nums1[p1];
                        p1++;
                    }
                    else
                    {
                        merged[i] = nums2[p2];
                        p2++;
                    }
                }
                else if (p1 < nums1.Length)
                {
                    merged[i] = nums1[p1];
                    p1++;
                }
                else
                {
                    merged[i] = nums2[p2];
                    p2++;
                }
            }
            
            if (isEven)
            {
                return (merged[merged.Length - 1] + merged[merged.Length - 2]) / 2.0;
            }
            else
            {
                return merged[merged.Length - 1];
            }
        }
    }


}
