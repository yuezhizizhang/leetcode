/**
 * Pow(x, n)
 * https://leetcode.com/problems/powx-n/
 * 
 * Implement pow(x, n), which calculates x raised to the power n (xn).
 * 
 * Example 1:
 * Input: 2.00000, 10
 * Output: 1024.00000
 * 
 * Example 2:
 * Input: 2.00000, -2
 * Output: 0.25000
 * Explanation: 2-2 = 1/22 = 1/4 = 0.25
 * 
 * Note:
 * -100.0 < x < 100.0
 * n is a 32-bit signed integer, within the range [?231, 231 ? 1]
 */
/**
 * @param {number} x
 * @param {number} n
 * @return {number}
 */
var myPow = function(x, n) {
  if (n === 0) {
    return 1;
  }
  
  const halfN = n < 0 ?
    Math.ceil(n / 2) :
  	Math.floor(n / 2);
  
  const halfer = myPow(x, halfN);
  
  if (n % 2 === 0) {
    return halfer * halfer;
  }
  
  if (n > 0) {
    return halfer * halfer * x;
  }
  
  return halfer * halfer / x;
};