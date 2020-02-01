/**
 * K-th Symbol in Grammar
 * https://leetcode.com/problems/k-th-symbol-in-grammar/
 *
 * On the first row, we write a 0. Now in every subsequent row,
 * we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
 * 
 * Given row N and index K, return the K-th indexed symbol in row N. (The values of K are 1-indexed.) (1 indexed).
 * 
 * Examples:
 * Input: N = 1, K = 1
 * Output: 0
 * 
 * Input: N = 4, K = 5
 * Output: 1
 * 
 * Explanation:
 * row 1: 0
 * row 2: 01
 * row 3: 0110
 * row 4: 01101001
 * 
 * Note:
 * 1. N will be an integer in the range [1, 30].
 * 2. K will be an integer in the range [1, 2^(N-1)].
 */
/**
 * Recurrsion: f(N, K) -> f(N - 1, (K + 1) / 2)
 * 
 * @param {number} N
 * @param {number} K
 * @return {number}
 */
var kthGrammar = function(N, K) {
  if (N === 1) {
    return 0;
  }
  
  const digit = kthGrammar(N - 1, Math.floor((K + 1) / 2));
  
  // 0 -> 01, 1 -> 10
  if (K % 2 === 0) {
    // Flip the digit
    return digit === 0 ? 1 : 0;
  } else {
	// Same digit
    return digit;
  }
};

/**
 * Tail recursion - XOR Gate Binary Tree
 * 
 * @param {number} N
 * @param {number} K
 * @return {number}
 */
var kthGrammar = function(N, K, xorOperator = 0) {
  if (N === 1) {
    return 0 ^ xorOperator;
  }
  
  if (K % 2 !== 0) {
    // Left child
    xorOperator ^= 0;
  } else {
    // Right child
    xorOperator ^= 1;
  }
  
  return kthGrammar(N - 1, Math.floor((K + 1) / 2), xorOperator);
}