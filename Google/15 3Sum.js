/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var threeSum = function(nums) {
    if (!nums || nums.length < 3) {
    	return [];
    }

    nums.sort((a, b) => a - b);

    let result = [];
    for (let i = 0; i < nums.length; i++) {
    	if (i > 0 && nums[i] == nums[i - 1]) {
    		continue;
    	}

    	let triples = twoSum(nums, i + 1, -nums[i]);
    	result = [...result, ...triples];
    }

    return result;
};

var twoSum = function(nums, start, target) {
	let result = [];

	let left = start;
	let right = nums.length - 1;
	while (left < right)
	{
		let sum = nums[left] + nums[right];
		if (sum === target) {
			result.push([-target, nums[left++], nums[right--]]);

			while (left < right && nums[left] === nums[left - 1]) {
				left++;
			}

			while (left < right && nums[right] === nums[right + 1]) {
				right--;
			}
		} else if (sum < target) {
			left++;
		} else {
			right--;
		}
	}

	return result;
}

threeSum([-1,0,1,2,-1,-4]);