## 946. Validate Stack Sequences
https://leetcode.com/problems/validate-stack-sequences/

> Given two integer arrays pushed and popped each with distinct values, return true if this could have been the result of a sequence of push and pop operations on an initially empty stack, or false otherwise.
>
> Example 1:
>   Input: pushed = [1,2,3,4,5], popped = [4,5,3,2,1]
>   Output: true
>   Explanation: We might do the following sequence:
>     push(1), push(2), push(3), push(4),
>     pop() -> 4,
>     push(5),
>     pop() -> 5, pop() -> 3, pop() -> 2, pop() -> 1
>
> Example 2:
>   Input: pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
>   Output: false
>   Explanation: 1 cannot be popped before 2.
>
> Constraints:
> * 1 <= pushed.length <= 1000
> * 0 <= pushed[i] <= 1000
> * All the elements of pushed are unique.
> * popped.length == pushed.length
> * popped is a permutation of pushed.

** Solution **

Time Complexity: O(N), Space Complexity: O(N)

```C#
public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var length = pushed.Length;
        var stack = new Stack<int>();
        var curr = 0;
        for (var i = 0; i < length; i++)
        {
            stack.Push(pushed[i]);
            while (stack.Count > 0 && curr < length && stack.Peek() == popped[curr])
            {
                stack.Pop();
                curr++;
            }
        }

        return curr == length;
    }
}
```

```JavaScript
/**
 * @param {number[]} pushed
 * @param {number[]} popped
 * @return {boolean}
 */
var validateStackSequences = function(pushed, popped) {
    const length = pushed.length;
    let stack = [];
    let curr = 0;

    for (let num of pushed) {
    	stack.push(num);

    	while (stack.length > 0 && curr < length && stack[stack.length - 1] === popped[curr]) {
    		stack.pop();
    		curr++;
    	}
    }

    return curr === length;
};
```