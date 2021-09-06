## 1007. Minimum Domino Rotations For Equal Row
https://leetcode.com/problems/minimum-domino-rotations-for-equal-row/

> In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the ith domino. (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
> We may rotate the ith domino, so that tops[i] and bottoms[i] swap values.
> Return the minimum number of rotations so that all the values in tops are the same, or all the values in bottoms are the same.
> If it cannot be done, return -1.
>
> Example 1:
> Input: tops = [2,1,2,4,2,2], bottoms = [5,2,6,2,3,2]
> Output: 2
> Explanation: 
>   The first figure represents the dominoes as given by tops and bottoms: before we do any rotations.
>   If we rotate the second and fourth dominoes, we can make every value in the top row equal to 2, as indicated by the second figure.
>
> Example 2:
> Input: tops = [3,5,1,2,3], bottoms = [3,6,3,3,4]
> Output: -1
> Explanation: 
>   In this case, it is not possible to rotate the dominoes to make one row of values equal.
>
> Constraints:
> * 2 <= tops.length <= 2 * 104
> * bottoms.length == tops.length
> * 1 <= tops[i], bottoms[i] <= 6

** Solution **

1. Pick up the first element. It has two sides: A[0] and B[0].

2. Check if one could make all elements in A row or B row to be equal to A[0]. If yes, return the minimum number of rotations needed.

3. Check if one could make all elements in A row or B row to be equal to B[0]. If yes, return the minimum number of rotations needed.

4. Otherwise return -1.

```C#
public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        if (tops.Length != bottoms.Length)
        {
            throw new ArgumentException();
        }

        if (tops.Length < 2)
        {
            return 0;
        }

        var size = tops.Length;
        var rotations = CheckRotations(tops[0], tops, bottoms, size);
        if (rotations != -1  || tops[0] == bottoms[0])
        {
            return rotations;
        }
        return CheckRotations(bottoms[0], tops, bottoms, size);
    }

    public int CheckRotations(int target, int[] tops, int[] bottoms, int length)
    {
        var topRotations = 0;
        var bottomRotations = 0;
        for (var i = 0; i < length; i++)
        {
            var up = tops[i];
            var down = bottoms[i];

            if (up != target && down != target)
            {
                return -1;
            }
            else if (up != target)
            {
                topRotations += 1;
            }
            else if (down != target)
            {
                bottomRotations += 1;
            }
        }

        return Math.Min(topRotations, bottomRotations);
    }
}
```

```JavaScript
/**
 * @param {number[]} tops
 * @param {number[]} bottoms
 * @return {number}
 */
var minDominoRotations = function(tops, bottoms) {
    if (tops.length < 2) {
    	return 0;
    }

    let size = tops.length;
    let rotations = checkRotations(tops[0], tops, bottoms, size);
    if (rotations != -1 || tops[0] == bottoms[0]) {
    	return rotations;
    }
    return checkRotations(bottoms[0], tops, bottoms, size);
};

var checkRotations = function(target, tops, bottoms, length) {
	let topRotations = 0;
	let bottomRotations = 0;

	for (let i = 0; i < length; i++) {
		if (tops[i] != target && bottoms[i] != target) {
			return -1;
		} else if (tops[i] != target) {
			topRotations += 1;
		} else if (bottoms[i] != target) {
			bottomRotations += 1;
		}
	}

	return Math.min(topRotations, bottomRotations);
};
```