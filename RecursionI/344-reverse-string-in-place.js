/**
 * Reverse String
 * https://leetcode.com/problems/reverse-string/
 *
 * Write a function that reverses a string. The input string is given as an array of characters char[].
 * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
 * You may assume all the characters consist of printable ascii characters.
 * 
 * @param {character[]} s
 * @return {void} Do not return anything, modify s in-place instead.
 */
var reverseString = function(s, start, end) {
    if (!s ||
        s.length < 2 ||
        start >= end) {
        return;
    }
    
    if (start === undefined || start < 0) {
        start = 0;
    }
    
    if (end === undefined || end >= s.length) {
        end = s.length - 1;
    }
    
    const temp = s[start];
    s[start] = s[end];
    s[end] = temp;
    reverseString(s, ++start, --end);
};