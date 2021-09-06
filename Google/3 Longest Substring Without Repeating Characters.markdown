## 3. Longest Substring Without Repeating Characters
https://leetcode.com/problems/longest-substring-without-repeating-characters/

> Given a string s, find the length of the longest substring without repeating characters.
>
> Example 1:
>   Input: s = "abcabcbb"
>   Output: 3
>   Explanation: The answer is "abc", with the length of 3.
>
> Example 2:
>   Input: s = "bbbbb"
>   Output: 1
>   Explanation: The answer is "b", with the length of 1.
>
> Example 3:
>   Input: s = "pwwkew"
>   Output: 3
>   Explanation: The answer is "wke", with the length of 3.
>   Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
>
> Example 4:
>   Input: s = ""
>   Output: 0
>
> Constraints:
> * 0 <= s.length <= 5 * 104
> * s consists of English letters, digits, symbols and spaces.

** Solution **

Use the sliding window solution. Use a Dictionary to mark if a char occurred or not.

Time Complexity: O(n), Space Complexity: O(n)

```C#
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var start = 0;
        var max = 1;
        var total = 1;
        var charsMap = new Dictionary<char, int>
        {
            { s[0], 0 },
        };

        for (var j = 1; j < s.Length; j++)
        {
            var key = s[j];
            if (charsMap.ContainsKey(key) && charsMap[key] >= start)
            {
                max = Math.Max(max, total);
                start = charsMap[key] + 1;
                total = j - start;
            }

            charsMap[key] = j;
            total++;
        }

        max = Math.Max(max, total);

        return max;
    }
}
```

```JavaScript
/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function(s) {
    if (!s) {
    	return 0;
    }

    let start = 0;
    let end = 1;
    let max = 1;
    let total = 1;
    let charsMap = new Map();
    charsMap.set(s[0], 0);

    for (let j = 1; j < s.length; j++) {
    	let key = s[j];
    	if (charsMap.has(key) && charsMap.get(key) >= start) {
    		max = Math.max(max, total);
    		start = charsMap.get(key) + 1;
    		total = j - start;
    	}

    	charsMap.set(key, j);
    	total++;
    }

    max = Math.max(max, total);

    return max;
};
```