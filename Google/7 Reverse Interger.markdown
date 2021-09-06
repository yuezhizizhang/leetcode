## 7. Reverse Integer
https://leetcode.com/problems/reverse-integer/

> Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
> Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
>
> Example 1:
>   Input: x = 123
>   Output: 321
>
> Example 2:
>   Input: x = -123
>   Output: -321
>
> Example 3:
>   Input: x = 120
>   Output: 21
>
> Example 4:
>   Input: x = 0
>   Output: 0
>
> Constraints:
> * -2^31 <= x <= 2^31 - 1

** Solution **

https://stackoverflow.com/questions/55928819/reverse-integer-leetcode-why-does-overflow-occur-only-if-7-or-greater-is-added

```C#
public class Solution {
    public int Reverse(int x) {
        var maxValueByTen = int.MaxValue / 10;
        var minValueByTen = int.MinValue / 10;

        var rev = 0;
        while (x != 0)
        {
            var ones = x % 10;
            x /= 10;
            if (rev > maxValueByTen || (rev == maxValueByTen && ones > 7))
            {
                return 0;
            }
            if (rev < minValueByTen || (rev == minValueByTen && ones < -8))
            {
                return 0;
            }
            rev = rev * 10 + ones;
        }

        return rev;
    }
}
```

```JavaScript
/**
 * @param {number} x
 * @return {number}
 */
var reverse = function(x) {
    const maxValueByTen = Math.trunc(Math.pow(2, 31) / 10);

	let isNegative = false;
	if (x < 0) {
		isNegative = true;
		x = -x;
	}

    let numStr = '' + x;
    let result = 0;
    for (let i = numStr.length - 1; i >= 0; i--) {
    	let ones = Number(numStr[i]);
    	if (result > maxValueByTen || 
    		(isNegative && result === maxValueByTen && ones > 8) ||
    		(result === maxValueByTen && ones > 7)) {
    		return 0;
    	}

    	result = result * 10 + ones;
    }

    return isNegative ? -result : result;
};
```