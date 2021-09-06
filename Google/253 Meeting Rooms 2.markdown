## 253. Meeting Rooms II
https://leetcode.com/problems/meeting-rooms-ii/

> Given an array of meeting time intervals intervals where intervals[i] = [starti, endi], return the minimum number of conference rooms required.
>
> Example 1:
>   Input: intervals = [[0,30],[5,10],[15,20]]
>   Output: 2
>
> Example 2:
>   Input: intervals = [[7,10],[2,4]]
>   Output: 1
>
> Constraints:
> * 1 <= intervals.length <= 104
> * 0 <= starti < endi <= 106

** Solution **

Time Complexity: O(nlogn), Space Complexity: O(n)

```C#
public class Solution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals == null || intervals.Length < 1)
        {
            return 0;
        }

        var size = intervals.Length;
        if (size == 1)
        {
            return 1;
        }

        var starts = new int[size];
        var ends = new int[size];

        for (var i = 0; i < size; i++)
        {
            starts[i] = intervals[i][0];
            ends[i] = intervals[i][1];
        }

        Array.Sort(starts);
        Array.Sort(ends);

        var rooms = 0;
        var endPtr = 0;
        for (var i = 0; i < size; i++)
        {
            if (starts[i] < ends[endPtr])
            {
                rooms++;
            }
            else
            {
                endPtr++;
            }
        }

        return rooms;
    }
}
```

```JavaScript
/**
 * @param {number[][]} intervals
 * @return {number}
 */
var minMeetingRooms = function(intervals) {
    let starts = intervals.sort((a, b) => a[0] - b[0]);
    let ends = [...intervals].sort((a, b) => a[1] - b[1]);

    let rooms = 0;
    let endIndex = 0;
    for (let i = 0; i < intervals.length; i++) {
    	if (starts[i][0] < ends[endIndex][1]) {
    		rooms++;
    	} else {
    		endIndex++;
    	}
    }

    return rooms;
};
```

