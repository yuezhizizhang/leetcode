## 20. Valid Parentheses
https://leetcode.com/problems/valid-parentheses/

> Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
> An input string is valid if:
> 1. Open brackets must be closed by the same type of brackets.
> 2. Open brackets must be closed in the correct order.
>
> Example 1:
>   Input: s = "()"
>   Output: true
>
> Example 2:
>   Input: s = "()[]{}"
>   Output: true
>
> Example 3:
>   Input: s = "(]"
>   Output: false
>
> Example 4:
>   Input: s = "([)]"
>   Output: false
>
> Example 5:
>   Input: s = "{[]}"
>   Output: true
>
> Constraints:
> * 1 <= s.length <= 104
> * s consists of parentheses only '()[]{}'.

** Solution **

Time Complexity: O(n), Space Complexity: O(n)

```C#
public class Solution {
    public bool IsValid(string s) {
        var bracketPairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }, 
        };

        var stack = new Stack<char>();
        for (var i = 0; i < s.Length; i++)
        {
            var key = s[i];
            if (bracketPairs.ContainsKey(key))
            {
                stack.Push(key);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                var top = stack.Pop();
                if (key != bracketPairs[top])
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
```

```JavaScript
/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function(s) {
    const bracketPairs = {
		'(': ')',
		'{': '}',
		'[': ']'
	};

	let stack = [];
	for (let i = 0; i < s.length; i++) {
		let key = s[i];
		if (bracketPairs.hasOwnProperty(key))
		{
			stack.push(key);
		} else {
			if (stack.length === 0)
			{
				return false;
			}

			var top = stack.pop();
			if (key !== bracketPairs[top])
			{
				return false;
			}
		}
	}

	return stack.length === 0;
};
```