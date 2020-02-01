/**
 * 198. House Robber
 * https://leetcode.com/problems/house-robber/
 * 
 * You are a professional robber planning to rob houses along a street. Each house has a certain amount of money
 * stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system
 * connected and it will automatically contact the police if two adjacent houses were broken into on the same
 * night.
 * 
 * Given a list of non-negative integers representing the amount of money of each house, determine the maximum
 * amount of money you can rob tonight without alerting the police.
 * 
 * Example 1:
 * Input: [1,2,3,1]
 * Output: 4
 * Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
 *              Total amount you can rob = 1 + 3 = 4.
 */            
/**
 * A typical recursion problem
 * F(N, 0) -> max(N0 + F(N, 2), N1 + F(N, 3))
 * 
 * The following method I provided is:
 * 
 * Runtime: 44 ms, faster than 98.16% of JavaScript online submissions for House Robber.
 * Memory Usage: 32.5 MB, less than 100.00% of JavaScript online submissions for House Robber.
 * 
 * @param {number[]} nums
 * @return {number}
 */
var rob = function(nums, start = 0, dict = {}) {
  if (!nums || start >= nums.length) {
      return 0;
  }
  
  if (start === nums.length - 1) {
    dict[start] = nums[start];
  } else {
    const hop2 = start + 2;
    const maxSumHop2 = dict.hasOwnProperty(hop2) ?
      dict[hop2] : rob(nums, hop2, dict);
    
    const hop3 = start + 3;
    const maxSumHop3 = dict.hasOwnProperty(hop3) ?
      dict[hop3] : rob(nums, hop3, dict);
    
    dict[start] = Math.max(nums[start] + maxSumHop2, nums[start + 1] + maxSumHop3);
  }
  
  return dict[start];
};