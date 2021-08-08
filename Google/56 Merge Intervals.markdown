## 56. Merge Intervals
https://leetcode.com/problems/merge-intervals/

> Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
>
> Example 1:
>   Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
>   Output: [[1,6],[8,10],[15,18]]
>   Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
>
> Example 2:
>    Input: intervals = [[1,4],[4,5]]
>    Output: [[1,5]]
>    Explanation: Intervals [1,4] and [4,5] are considered overlapping.
>
> Constraints
> * 1 <= intervals.length <= 104
> * intervals[i].length == 2
> * 0 <= starti <= endi <= 104

**Solution:**

First, sort the intervals by start. Then loop through the sorted list, if one interval's start falls in the previous interval, then the 2 intervals can combine.

Time Complexity: O(nlogn), Space Complexity: O(n)

```C#
public class Solution {
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        foreach (var interval in intervals)
        {
            var last = merged.Count > 0 ? merged.Last() : null;
            if (last != null && interval[0] <= last[1])
            {
                last[1] = Math.Max(last[1], interval[1]);
            }
            else
            {
                merged.Add(interval);
            }
        }

        return merged.ToArray();
    }
}
```

```JavaScript
/**
 * @param {number[][]} intervals
 * @return {number[][]}
 */
var merge = function(intervals) {
    intervals.sort((a, b) => a[0] - b[0]);

    let merged = [];
    for (let interval of intervals) {
    	let last = merged.length > 0 ? merged[merged.length - 1] : null;
    	if (last != null && interval[0] <= last[1]) {
    		last[1] = Math.max(last[1], interval[1]);
    	} else {
    		merged.push(interval);
    	}
    }

    return merged;
};
```