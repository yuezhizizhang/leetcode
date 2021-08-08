## 1. Two Sum
https://leetcode.com/problems/two-sum/

> Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
> You may assume that each input would have exactly one solution, and you may not use the same element twice.
> You can return the answer in any order.
>
> Example 1:
>  Input: nums = [2,7,11,15], target = 9
>  Output: [0,1]
>  Output: Because nums[0] + nums[1] == 9, we return [0, 1].
>
> Example 2:
>  Input: nums = [3,2,4], target = 6
>  Output: [1,2]
>
> Constraints:
> * 2 <= nums.length <= 10^4
> * -10^9 <= nums[i] <= 10^9
> * -10^9 <= target <= 10^9
> * Only one valid answer exists.

**Solution:**

We add each element's value as a key and its index as a value to the hash table. While we are iterating and inserting elements into the hash table, we also look back to check if current element's complement already exists in the hash table. If it exists, we have found a solution and return the indices immediately.

Time Complexity: O(n), Space Complexity: O(n)

```C#
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var numToIndexMap = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (numToIndexMap.ContainsKey(diff))
            {
                return new int[] { numToIndexMap[diff], i };
            }

            if (!numToIndexMap.ContainsKey(nums[i]))
            {
                numToIndexMap[nums[i]] = i;
            }
        }

        return null;
    }
}
```

```Javascript
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    let numToIndexMap = {};
    
    for (var i = 0; i < nums.length; i++) {
        let diff = target - nums[i];
        if (numToIndexMap.hasOwnProperty(diff)) {
            return [numToIndexMap[diff], i];
        }

        if (!numToIndexMap.hasOwnProperty(nums[i])) {
            numToIndexMap[nums[i]] = i;
        }
    }

    return null;
};
```