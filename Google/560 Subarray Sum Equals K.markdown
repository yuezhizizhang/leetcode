## 560. Subarray Sum Equals K
https://leetcode.com/problems/subarray-sum-equals-k/

> Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
>
> Example 1:
>   Input: nums = [1,1,1], k = 2
>   Output: 2
>
> Example 2:
>   Input: nums = [1,2,3], k = 3
>   Output: 2
>
> Constraints:
> * 1 <= nums.length <= 2 * 104
> * -1000 <= nums[i] <= 1000
> * -107 <= k <= 107

** Solution **

Watch this video to learn the O(n) algorithm. It's not very intuitive.

```C#
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var sums = new Dictionary<int, int> { { 0, 1 } };

        var total = 0;
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            total += nums[i];

            var key = total - k;
            if (sums.ContainsKey(key))
            {
                count += sums[key];
            }

            sums[total] = sums.GetValueOrDefault(total, 0) + 1;
        }

        return count;
    }
}
```

```JavaScript
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraySum = function(nums, k) {
    let sums = new Map();
    sums.set(0, 1);

    let total = 0;
    let count = 0;
    for (let i = 0; i < nums.length; i++) {
    	total += nums[i];

    	let key = total - k;
    	if (sums.has(key)) {
    		count += sums.get(key);
    	}

	    sums.set(total, sums.has(total) ? sums.get(total) + 1 : 1);
    }

    return count;
};
```