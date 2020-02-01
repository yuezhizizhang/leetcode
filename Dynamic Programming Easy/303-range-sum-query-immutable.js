/**
 * 303. Range Sum Query - Immutable
 * https://leetcode.com/problems/range-sum-query-immutable/
 * 
 * Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
 * 
 * Example:
 * Given nums = [-2, 0, 3, -5, 2, -1]
 * 
 * sumRange(0, 2) -> 1
 * sumRange(2, 5) -> -1
 * sumRange(0, 5) -> -3
 * 
 * Note:
 * 1. You may assume that the array does not change.
 * 2. There are many calls to sumRange function.
 */
/**
 * @param {number[]} nums
 */
var NumArray = function(nums) {
  this.sums = [];
  
  if (!!nums) {
    let sum = 0;
    nums.forEach(num => {
      sum += num;
      this.sums.push(sum);
    });
  }
};

/** 
 * @param {number} i 
 * @param {number} j
 * @return {number}
 */
NumArray.prototype.sumRange = function(i, j) {
  if (i >= this.sums.length || j < 0 || i > j) {
    return 0;
  }
  
  if (j >= this.sums.length) {
    j = this.sums.length - 1;
  }
  
  if (i <= 0) {
    return this.sums[j];
  } else {
    return this.sums[j] - this.sums[i - 1];
  }
};

/** 
 * Your NumArray object will be instantiated and called as such:
 * var obj = new NumArray(nums)
 * var param_1 = obj.sumRange(i,j)
 */