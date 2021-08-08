## 4. Median of Two Sorted Arrays
https://leetcode.com/problems/median-of-two-sorted-arrays/

> Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
> The overall run time complexity should be O(log (m+n)).
>
> Example 1:
>   Input: nums1 = [1,3], nums2 = [2]
>   Output: 2.00000
>   Explanation: merged array = [1,2,3] and median is 2.
>
> Example 2:
>   Input: nums1 = [1,2], nums2 = [3,4]
>   Output: 2.50000
>   Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
>
> Example 3:
>   Input: nums1 = [0,0], nums2 = [0,0]
>   Output: 0.00000
>
> Example 4:
>   Input: nums1 = [], nums2 = [1]
>   Output: 1.00000
>
> Example 5:
>   Input: nums1 = [2], nums2 = []
>   Output: 2.00000
>
> Constraints:
> * nums1.length == m
> * nums2.length == n
> * 0 <= m <= 1000
> * 0 <= n <= 1000
> * 1 <= m + n <= 2000
> * -106 <= nums1[i], nums2[i] <= 106

**Solution:** 

```C#
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var totalLength = nums1.Length + nums2.Length;
        var median = (int)((totalLength - 1) / 2);
        var isEven = totalLength % 2 == 0;

        var m1 = 0;
        var m2 = 0;
        var p1 = 0;
        var p2 = 0;
        var count = 0;
        while (p1 < nums1.Length && p2 < nums2.Length)
        {
            if (count > median + 1)
            {
                break;
            }

            if (nums1[p1] <= nums2[p2])
            {
                if (count == median)
                {
                    m1 = nums1[p1];
                }

                if (count == median + 1)
                {
                    m2 = nums1[p1];
                }

                p1++;
            } 
            else
            {
                if (count == median)
                {
                    m1 = nums2[p2];
                }

                if (count == median + 1)
                {
                    m2 = nums2[p2];
                }

                p2++;

            }

            count++;
        }

        var nums = p1 < nums1.Length ? nums1 : nums2;
        var p = p1 < nums1.Length ? p1 : p2;
        if (count <= median)
        {
            var index = p + median - count;
            m1 = nums[index];
        }

        if (isEven && count <= median + 1)
        {
            var index = p + median + 1 - count;
            m2 = nums[index];
        }

        if (isEven)
        {
            return (m1 + m2) / 2.0;
        }
        else
        {
            return m1;
        }
    }
}
```

```JavaScript
/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function(nums1, nums2) {
    let totalLength = nums1.length + nums2.length;
    let isEven = totalLength % 2 === 0;
    let size = isEven ? totalLength / 2 + 1 : (totalLength + 1) / 2;

    let [current, prev] = [0, 0];
    let [p1, p2] = [0, 0];
    for (let i = 0; i < size; i++) {
        if (p1 < nums1.length && p2 < nums2.length) {
            if (nums1[p1] <= nums2[p2]) {
                prev = current;
                current = nums1[p1];
                p1++;
            } else {
                prev = current;
                current = nums2[p2];
                p2++;
            }
        } else if (p1 < nums1.length) {
            prev = current;
            current = nums1[p1];
            p1++;
        } else {
            prev = current;
            current = nums2[p2];
            p2++;
        }
    }

    if (isEven) {
        return (prev + current) / 2.0;
    } else {
        return current;
    }
};
```