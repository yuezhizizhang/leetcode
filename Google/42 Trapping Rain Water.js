/**
 * @param {number[]} height
 * @return {number}
 */
var trap = function(height) {
    let size = height.length;
    if (size <= 2) {
    	return 0;
    }

    let leftMax = new Array(size);
    leftMax[0] = [height[0]];
    let rightMax = new Array(size);
    rightMax[size - 1] = height[size - 1];
    for (let i = 1; i < size; i++) {
    	leftMax[i] = Math.max(leftMax[i - 1], height[i]);
    	rightMax[size - i - 1] = Math.max(rightMax[size - i], height[size - i - 1]);
    }

    let totalWater = 0;
    for (let i = 1; i < size - 1; i++) {
    	totalWater += Math.min(leftMax[i], rightMax[i]) - height[i];
    }

    return totalWater;
};

trap([0,1,0,2,1,0,1,3,2,1,2,1]);