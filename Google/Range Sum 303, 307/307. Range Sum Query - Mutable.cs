using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = new NumArray(new int[] { 1, 3, 5 });
            var sum = arr.SumRange(0, 2);
        }
    }

    public class NumArray
    {
        private int _size;
        private int[] _tree;

        public NumArray(int[] nums)
        {
            if (nums == null || nums.Length <= 0) throw new ArgumentException("number array can't be empty");

            this._size = nums.Length;
            this._tree = new int[4 * this._size];
            this.BuildTree(nums, 0, this._size - 1, 1);
        }

        public void Update(int index, int val)
        {
            if (index < 0 || index >= this._size) return;

            this.UpdateTree(0, this._size - 1, index, 1, val);
        }

        public int SumRange(int left, int right)
        {
            return this.SumTree(left, right, 0, this._size - 1, 1);
        }

        private void BuildTree(int[] nums, int left, int right, int index)
        {
            if (left == right)
            {
                this._tree[index] = nums[left];
                return;
            }

            var mid = (left + right) / 2;
            var leftChild = index << 1;
            var rightChild = index << 1 | 1;
            this.BuildTree(nums, left, mid, leftChild);
            this.BuildTree(nums, mid + 1, right, rightChild);
            this._tree[index] = this._tree[leftChild] + this._tree[rightChild];
        }

        private void UpdateTree(int left, int right, int pos, int index, int value)
        {
            if (left == right)
            {
                this._tree[index] = value;
                return;
            }

            var mid = (left + right) / 2;
            var leftChild = index << 1;
            var rightChild = index << 1 | 1;
            if (pos <= mid)
            {
                this.UpdateTree(left, mid, pos, leftChild, value);
            }
            else
            {
                this.UpdateTree(mid + 1, right, pos, rightChild, value);
            }

            this._tree[index] = this._tree[leftChild] + this._tree[rightChild];
        }

        private int SumTree(int qleft, int qright, int left, int right, int index)
        {
            if (left >= qleft && right <= qright) return this._tree[index];
            if (right < qleft || left > qright) return 0;

            var mid = (left + right) / 2;
            return this.SumTree(qleft, qright, left, mid, index << 1) +
                this.SumTree(qleft, qright, mid + 1, right, index << 1 | 1);
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * obj.Update(index,val);
     * int param_2 = obj.SumRange(left,right);
     */
}
