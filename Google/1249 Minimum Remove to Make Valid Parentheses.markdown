## 1249. Minimum Remove to Make Valid Parentheses
https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/

> Given a string s of '(' , ')' and lowercase English characters. 
> Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.
> Formally, a parentheses string is valid if and only if:
> * It is the empty string, contains only lowercase characters, or
> * It can be written as AB (A concatenated with B), where A and B are valid strings, or
> * It can be written as (A), where A is a valid string.
>
> Example 1:
>   Input: s = "lee(t(c)o)de)"
>   Output: "lee(t(c)o)de"
>   Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.
>
> Example 2:
>  Input: s = "a)b(c)d"
>  Output: "ab(c)d"
>
> Example 3:
>   Input: s = "))(("
>   Output: ""
>   Explanation: An empty string is also valid.
>
> Example 4:
>   Input: s = "(a(b(c)d)"
>   Output: "a(b(c)d)"
>
> Constraints:
> * 1 <= s.length <= 10^5
> * s[i] is one of  '(' , ')' and lowercase English letters.

** Solution **

Time Complexity: O(n), Space Complexity: O(n)

```C#
public class Solution {
    private const char RightBracket = ')';
    private const char LeftBracket = '(';

    public string MinRemoveToMakeValid(string s)
    {
        var stack = new Stack<int>();
        var set = new HashSet<int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == LeftBracket)
            {
                stack.Push(i);
            }
            else if (s[i] == RightBracket)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
                else
                {
                    set.Add(i);
                }
            }
        }

        set.UnionWith(stack);

        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            if (!set.Contains(i))
            {
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }
}
```

```JavaScript
/**
 * @param {string} s
 * @return {string}
 */
var minRemoveToMakeValid = function(s) {
    const leftBracket = '(';
	const rightBracket = ')';

    let stack = [];
    let result = [...s];
    for (let i = 0; i < s.length; i++) {
    	if (s[i] === leftBracket) {
    		stack.push(i);
    	} else if (s[i] === rightBracket) {
    		if (stack.length > 0) {
    			stack.pop();
    		} else {
    			result[i] = '';
    		}
    	}
    }

    for (let i of stack) {
    	result[i] = '';
    }

    return result.join('');
};
```