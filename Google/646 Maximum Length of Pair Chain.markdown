## 646. Maximum Length of Pair Chain
https://leetcode.com/problems/maximum-length-of-pair-chain/

> You are given an array of n pairs pairs where pairs[i] = [lefti, righti] and lefti < righti.
> A pair p2 = [c, d] follows a pair p1 = [a, b] if b < c. A chain of pairs can be formed in this fashion.
> Return the length longest chain which can be formed.
> You do not need to use up all the given intervals. You can select pairs in any order.
>
> Example 1:
>   Input: pairs = [[1,2],[2,3],[3,4]]
>   Output: 2
>   Explanation: The longest chain is [1,2] -> [3,4].
>
> Example 2:
>   Input: pairs = [[1,2],[7,8],[4,5]]
>   Output: 3
>   Explanation: The longest chain is [1,2] -> [4,5] -> [7,8].
>
> Constraints:
>   n == pairs.length
>   1 <= n <= 1000
>   -1000 <= lefti < righti < 1000

** Solution **

```C#
public class Solution
{
    public int FindLongestChain(int[][] pairs)
    {
        Array.Sort(pairs, new PairComparer());

        var length = pairs.Length;
        var longest = new int[length];
        for (var i = 0; i < length; i++)
        {
            longest[i] = -1;
        }

        return FindLongestChainFrom(pairs, longest, length, 0);
    }

    private int FindLongestChainFrom(int[][] pairs, int[] longest, int length, int position)
    {
        if (position >= length || position < 0)
        {
            return 0;
        }

        if (longest[position] != -1)
        {
            return longest[position];
        }

        int nextPosition = FindNextPair(pairs, pairs[position][1], position);

        var max = Math.Max(FindLongestChainFrom(pairs, longest, length, position + 1),
            1 + FindLongestChainFrom(pairs, longest, length, nextPosition));

        longest[position] = max;

        return max;
    }

    private int FindNextPair(int[][] pairs, int greater, int start)
    {
        int end = pairs.Length - 1;
        int nextPosition = pairs.Length;

        while (start <= end)
        {
            var mid = (start + end) / 2;
            if (pairs[mid][0] > greater)
            {
                nextPosition = mid;
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return nextPosition;
    }
}

class PairComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return ((int[])x)[0] - ((int[])y)[0];
    }
}
```

```JavaScript
/**
 * @param {number[][]} pairs
 * @return {number}
 */
var findLongestChain = function(pairs) {
	let length = pairs.length;

	pairs.sort((a, b) => a[0] - b[0]);

	let longest = [];
	for (let i = 0; i < length; i++) {
		longest[i] = -1;
	}

	return findLongestChainFrom(pairs, longest, length, 0);
};

var findLongestChainFrom = function (pairs, longest, length, position) {
	if (position >= length || position < 0) {
		return 0;
	}

	if (longest[position] !== -1) {
		return longest[position];
	}

	let nextIndex = findNextPair(pairs, pairs[position][1], position + 1);

	let max = Math.max(findLongestChainFrom(pairs, longest, length, position + 1),
		1 + findLongestChainFrom(pairs, longest, length, nextIndex));

	longest[position] = max;

	return max;
}

var findNextPair = function(pairs, greater, start) {
	let end = pairs.length - 1;
	let nextIndex = pairs.length;

	while (start <= end) {
		let mid = Math.floor((start + end) / 2);
		if (pairs[mid][0] > greater) {
			nextIndex = mid;
			end = mid - 1;
		} else {
			start = mid + 1;
		}
	}

	return nextIndex;
};
```