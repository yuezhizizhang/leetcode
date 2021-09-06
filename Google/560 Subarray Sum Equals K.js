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

subarraySum([1, -1, 0], 1);