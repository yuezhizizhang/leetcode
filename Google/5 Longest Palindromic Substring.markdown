## 5. Longest Palindromic Substring
https://leetcode.com/problems/longest-palindromic-substring/

> Given a string s, return the longest palindromic substring in s.
>
> Example 1:
>   Input: s = "babad"
>   Output: "bab"
>   Note: "aba" is also a valid answer.
>
> Example 2:
>   Input: s = "cbbd"
>   Output: "bb"
>
> Example 3:
>   Input: s = "a"
>   Output: "a"
>
> Example 4:
>   Input: s = "ac"
>   Output: "a"
>
> Constraints:
> * 1 <= s.length <= 1000
> * s consist of only digits and English letters.

** Solution **

https://www.youtube.com/watch?v=XYQecbcd6_c

```C#
public class Solution {
    public string LongestPalindrome(string s)
    {
        var longest = string.Empty;
        var max = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var result = FindLongestPalindrome(s, i, i, max);
            if (result != string.Empty)
            {
                longest = result;
                max = longest.Length;
            }

            result = FindLongestPalindrome(s, i, i + 1, max);
            if (result != string.Empty)
            {
                longest = result;
                max = longest.Length;
            }
        }

        return longest;
    }

    private string FindLongestPalindrome(string s, int l, int r, int max)
    {
        var longest = string.Empty;

        while (l >= 0 && r < s.Length)
        {
            if (s[l] != s[r])
            {
                break;
            }

            var length = r - l + 1;
            if (length > max)
            {
                longest = s.Substring(l, length);
                max = length;
            }

            l--;
            r++;
        }

        return longest;
    }
}
```

```JavaScript
/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function(s) {
    let longest = '';

    for (let i = 0; i < s.length; i++) {
    	let result = findLongestPalindrome(s, i, i, longest.length);
    	if (!!result) {
    		longest = result;
    	}
        
    	result = findLongestPalindrome(s, i, i + 1, longest.length);
    	if (!!result) {
    		longest = result;
    	}
    }

    return longest;
};

var findLongestPalindrome = function(s, l, r, max) {
	let longest = '';

	while (l >= 0 && r < s.length)
	{
		if (s[l] !== s[r]) {
			break;
		}

		var length = r - l + 1;
		if (length > max) {
			longest = s.substr(l, length);
		}

		l--;
		r++;
	}

	return longest;
}
```