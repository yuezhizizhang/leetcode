## 42. Trapping Rain Water
https://leetcode.com/problems/trapping-rain-water/

> Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
>
> Example 1:
>   Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
>   Output: 6
>   Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
>
> Example 2:
>   Input: height = [4,2,0,3,2,5]
>   Output: 9
>
> Constraints:
> * n == height.length
> * 1 <= n <= 2 * 104
> * 0 <= height[i] <= 105

**Solution:**

* Find maximum height of bar from the left end upto an index i in the array left_max.
* Find maximum height of bar from the right end upto an index i in the array right_max.
* Iterate over the height array and update ans:
  Add min(left_max[i],right_max[i])−height[i] to ans

Time Complexity: O(n), Space Complexity: O(n)

```C#
public class Solution {
    public int Trap(int[] height) {
        var size = height.Length;
        if (size <= 2)
        {
            return 0;
        }

        var leftMax = new int[size];
        leftMax[0] = height[0];
        var rightMax = new int[size];
        rightMax[size - 1] = height[size - 1];
        
        for (var i = 1; i < size; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            rightMax[size - i - 1] = Math.Max(rightMax[size - i], height[size - i - 1]);
        }

        var totalWater = 0;
        for (var i = 1; i < size - 1; i++)
        {
            totalWater += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return totalWater;
    }
}
```

```JavaScript
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
```