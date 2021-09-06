## 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/

> Given an array of integers nums and an integer limit, return the size of the longest non-empty subarray such that the absolute difference between any two elements of this subarray is less than or equal to limit.
>
> Example 1:
>   Input: nums = [8,2,4,7], limit = 4
>   Output: 2 
>   Explanation: All subarrays are: 
>     [8] with maximum absolute diff |8-8| = 0 <= 4.
>     [8,2] with maximum absolute diff |8-2| = 6 > 4. 
>     [8,2,4] with maximum absolute diff |8-2| = 6 > 4.
>     [8,2,4,7] with maximum absolute diff |8-2| = 6 > 4.
>     [2] with maximum absolute diff |2-2| = 0 <= 4.
>     [2,4] with maximum absolute diff |2-4| = 2 <= 4.
>     [2,4,7] with maximum absolute diff |2-7| = 5 > 4.
>     [4] with maximum absolute diff |4-4| = 0 <= 4.
>     [4,7] with maximum absolute diff |4-7| = 3 <= 4.
>     [7] with maximum absolute diff |7-7| = 0 <= 4. 
>     Therefore, the size of the longest subarray is 2.
>
> Example 2:
>   Input: nums = [10,1,2,4,7,2], limit = 5
>   Output: 4 
>   Explanation: The subarray [2,4,7,2] is the longest since the maximum absolute diff is |2-7| = 5 <= 5.
>
> Example 3:
>   Input: nums = [4,2,2,2,4,4,2,2], limit = 0
>   Output: 3
>
> Constraints:
> * 1 <= nums.length <= 105
> * 1 <= nums[i] <= 109
> * 0 <= limit <= 109

** Solution **

https://www.youtube.com/watch?v=LDFZm4iB7tA

Time Complexity: O(N), Space Complexity: O(N)

```C#
public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        if (nums == null || nums.Length < 1 || limit < 0)
        {
            throw new ArgumentException();
        }

        var max = new LinkedList<int>();
        var min = new LinkedList<int>();
        var left = 0;
        var right = 0;

        while (right < nums.Length)
        {
            var num = nums[right++];
            while (max.Count > 0 && num > max.Last.Value) max.RemoveLast();
            while (min.Count > 0 && num < min.Last.Value) min.RemoveLast();

            max.AddLast(num);
            min.AddLast(num);

            if (max.First.Value - min.First.Value <= limit) continue;

            num = nums[left++];
            if (max.First.Value == num) max.RemoveFirst();
            if (min.First.Value == num) min.RemoveFirst();
        }

        return right - left;
    }
}
```

```JavaScript
/**
 * @param {number[]} nums
 * @param {number} limit
 * @return {number}
 */
var longestSubarray = function(nums, limit) {
    let max = new LinkedList();
    let min = new LinkedList();
    let left = 0;
    let right = 0;

    while (right < nums.length) {
    	let num = nums[right++];
    	while (max.count > 0 && max.last.value < num) max.removeLast();
    	while (min.count > 0 && min.last.value > num) min.removeLast();

    	max.addLast(num);
    	min.addLast(num);

    	if (max.first.value - min.first.value <= limit) continue;

    	num = nums[left++];
    	if (max.first.value === num) max.removeFirst();
    	if (min.first.value === num) min.removeFirst();
    }
    
    return right - left;
};

class LinkedList {
	constructor() {
		this.head = null;
		this.tail = null;
		this.count = 0;
	}

	get first() {
		return this.head;
	}

	get last() {
		return this.tail;
	}

	addLast(num) {
		let node = new Node(num);

		if (!!this.tail) {
			this.tail.next = node;
			node.previous = this.tail;
		}

		this.count++;
		this.tail = node;
		if (!this.head) {
			this.head = node;
		}
	}

	removeLast() {
		if (this.count < 1) {
			return;
		}

		if (this.count === 1) {
			this.head = this.tail = null;
		} else {
			this.tail = this.tail.previous;
			this.tail.next = null;
		}
		this.count--;
	}

	removeFirst() {
		if (this.count < 1) {
			return;
		}

		if (this.count === 1) {
			this.head = this.tail = null;
		} else {
			let node = this.head.next;
			node.previous = null;
			this.head.next = null;
			this.head = node;
		}
		this.count--;
	}
}

class Node {
	constructor(value, next = null, previous = null) {
		this.value = value;
		this.next = next;
		this.previous = previous;
	}
}
```