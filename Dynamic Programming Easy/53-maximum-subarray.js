/**
 * 53. Maximum Subarray
 * https://leetcode.com/problems/maximum-subarray/
 * 
 * Given an integer array nums, find the contiguous subarray (containing at least one number)
 * which has the largest sum and return its sum.
 * 
 * Example:
 * Input: [-2,1,-3,4,-1,2,1,-5,4],
 * Output: 6
 * Explanation: [4,-1,2,1] has the largest sum = 6.
 */
/**
 * Time complexity - O(n)
 *
 * @param {number[]} nums
 * @return {number}
 */
var maxSubArray = function(nums) {
  if (!nums || nums.length < 1) {
    return Number.NaN;
  }
  
  let begin = 0,
    sum = nums[0],
    max = nums[0];
  for (let i = 1; i < nums.length; i++) {
    if (sum < 0) {
      begin = i;
      sum = 0;
    }
    
    sum += nums[i];
    max = Math.max(sum, max);
  }
    
  return max;
};

/**
 * Divide and Conquer
 * Time complexity - O(nlogn)
 * 
 * @param {number[]} nums
 * @return {number}
 */
var maxSubArray = function(nums, start, end) {
  if (!nums || nums.length < 1) {
    return Number.NaN;
  }
  
  if (start === undefined) {
      start = 0;
  }
  if (end === undefined) {
      end = nums.length - 1;
  }
  const middle = Math.floor((start + end) / 2);
  
  if (start === end) {
    return nums[start];
  }
  
  return Math.max(maxSubArray(nums, start, middle),
                  maxSubArray(nums, middle + 1, end),
                  maxCrossingArray(nums, start, end, middle));
}

var maxCrossingArray = function(nums, start, end, middle) {
  let maxLeft = 0;
  let sumLeft = 0;
  for (let i = middle - 1; i >= start; i--) {
    sumLeft += nums[i];
    if (sumLeft > maxLeft) {
      maxLeft = sumLeft;
    }
  }
  
  let maxRight = 0;
  let sumRight = 0;
  for (let i = middle + 1; i <= end; i++) {
    sumRight += nums[i];
    if (sumRight > maxRight) {
      maxRight = sumRight;
    }
  }
  
  return maxLeft + nums[middle] + maxRight;
}