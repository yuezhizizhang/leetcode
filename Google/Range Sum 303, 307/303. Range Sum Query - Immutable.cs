using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class NumArray
    {
        private int[] Sums { get; set; }

        public NumArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) throw new ArgumentException("nums array is null or empty.");

            this.Sums = new int[nums.Length];
            this.Sums[0] = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                this.Sums[i] = nums[i] + this.Sums[i - 1];
            }
        }

        public int SumRange(int left, int right)
        {
            if (left < 0 || right >= this.Sums.Length || left > right) throw new ArgumentOutOfRangeException();

            var subtract = left == 0 ? 0 : this.Sums[left - 1];
            return this.Sums[right] - subtract;
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(left,right);
     */
}
