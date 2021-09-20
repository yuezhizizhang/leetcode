## 659. Split Array into Consecutive Subsequences
https://leetcode.com/problems/split-array-into-consecutive-subsequences/

> You are given an integer array nums that is sorted in non-decreasing order.
> Determine if it is possible to split nums into one or more subsequences such that both of the following conditions are true:
> * Each subsequence is a consecutive increasing sequence (i.e. each integer is exactly one more than the previous integer).
> * All subsequences have a length of 3 or more.
> Return true if you can split nums according to the above conditions, or false otherwise.
> A subsequence of an array is a new array that is formed from the original array by deleting some (can be none) of the elements without disturbing the relative positions of the remaining elements. (i.e., [1,3,5] is a subsequence of [1,2,3,4,5] while [1,3,2] is not).
>
> Example 1:
>   Input: nums = [1,2,3,3,4,5]
>   Output: true
>   Explanation: nums can be split into the following subsequences:
>   [1,2,3,3,4,5] --> 1, 2, 3
>   [1,2,3,3,4,5] --> 3, 4, 5
>
> Example 2:
>   Input: nums = [1,2,3,3,4,4,5,5]
>   Output: true
>   Explanation: nums can be split into the following subsequences:
>   [1,2,3,3,4,4,5,5] --> 1, 2, 3, 4, 5
>   [1,2,3,3,4,4,5,5] --> 3, 4, 5
>
> Example 3:
>   Input: nums = [1,2,3,4,4,5]
>   Output: false
>   Explanation: It is impossible to split nums into consecutive increasing subsequences of length 3 or more.
>
> Constraints:
> * 1 <= nums.length <= 10^4
> * -1000 <= nums[i] <= 1000
> * nums is sorted in non-decreasing order.

** Solution **

https://www.youtube.com/watch?v=uJ8BAQ8lASE&t=554s

```C#
public class Solution {
    public bool IsPossible(int[] nums) {
        var counter = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (counter.ContainsKey(num))
                counter[num]++;
            else
                counter[num] = 1;
        }

        var ends = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (counter[num] < 1) continue;

            counter[num]--;
            if (ends.ContainsKey(num))
            {
                if (--ends[num] == 0) ends.Remove(num);

                this.AddEnds(ends, num + 1);
            }
            else
            {
                var i = 1;
                while (i < 3)
                {
                    var next = num + i++;
                    if (counter.ContainsKey(next) && counter[next] > 0)
                        counter[next]--;
                    else
                        return false;
                }

                this.AddEnds(ends, num + i);
            }
        }

        return true;
    }
    
    private void AddEnds(Dictionary<int, int> ends, int key)
    {
        if (ends.ContainsKey(key))
            ends[key]++;
        else
            ends.Add(key, 1);
    }
}
```

```JavaScript
/**
 * @param {number[]} nums
 * @return {boolean}
 */
var isPossible = function(nums) {
    let counter = {};
    for (let num of nums) {
    	if (counter.hasOwnProperty(num)) {
    		counter[num]++;
    	} else {
    		counter[num] = 1;
    	}
    }

    let ends = {};
    for (let num of nums) {
    	if (counter[num] === 0) continue;

    	counter[num]--;
    	if (ends.hasOwnProperty(num) && ends[num] > 0) {
    		ends[num]--;

    		let next = num + 1;
    		if (ends.hasOwnProperty(next)) {
    			ends[next]++;
    		} else {
    			ends[next] = 1;
    		}
    	} else {
    		let incr = 1;
    		while (incr < 3) {
    			let next = num + incr++;
    			if (counter.hasOwnProperty(next) && counter[next] > 0) {
    				counter[next]--;
    			} else {
    				return false;
    			}
    		}

            let value = num + incr;
            if (ends.hasOwnProperty(value)) {
                ends[value]++;
            } else {
                ends[value] = 1;
            }
    	}
    }

    return true;
};
```