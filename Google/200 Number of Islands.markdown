## 200. Number of Islands
https://leetcode.com/problems/number-of-islands/

> Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
> An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
>
> Example 1:
>
> Input: grid = [
>   ["1","1","1","1","0"],
>   ["1","1","0","1","0"],
>   ["1","1","0","0","0"],
>   ["0","0","0","0","0"]
> ]
> Output: 1
>
> Example 2:
>
> Input: grid = [
>   ["1","1","0","0","0"],
>   ["1","1","0","0","0"],
>   ["0","0","1","0","0"],
>   ["0","0","0","1","1"]
> ]
> Output: 3
>
> Constraints:
> * m == grid.length
> * n == grid[i].length
> * 1 <= m, n <= 300
> * grid[i][j] is '0' or '1'.

**Solution:**

The connected '1's form a tree. It is to traverse each tree. Count how many trees are there. DFS via recursion is much faster than via Stack.

Time Complexity: O(m * n), Space Complexity: O(1)

```C#
public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var total = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    Visit(grid, i, j);
                    total++;
                }
            }
        }

        return total;
    }

    private void Visit(char[][] grid, int row, int col)
    {
        var stack = new Stack<(int, int)>();

        stack.Push((row, col));
        while(stack.Count > 0)
        {
            var (i, j) = stack.Pop();
            grid[i][j] = '0';

            // top
            if (i - 1 >= 0 && grid[i - 1][j] == '1')
            {
                stack.Push((i - 1, j));
            }

            // bottom
            if (i + 1 < grid.Length && grid[i + 1][j] == '1')
            {
                stack.Push((i + 1, j));
            }

            // left
            if (j - 1 >= 0 && grid[i][j - 1] == '1')
            {
                stack.Push((i, j - 1));
            }

            // right
            if (j + 1 < grid[i].Length && grid[i][j + 1] == '1')
            {
                stack.Push((i, j + 1));
            }
        }
    }

    private void DfsVisit(char[][] grid, int row, int col, int width, int height)
    {
        if (row < 0
           || col < 0
           || row >= height
           || col >= width
           || grid[row][col] == '0')
        {
            return;
        }
        
        grid[row][col] = '0';
        DfsVisit(grid, row - 1, col, width, height);
        DfsVisit(grid, row + 1, col, width, height);
        DfsVisit(grid, row, col - 1, width, height);
        DfsVisit(grid, row, col + 1, width, height);
    }
}
```

```JavaScript
/**
 * @param {character[][]} grid
 * @return {number}
 */
/**
 * @param {character[][]} grid
 * @return {number}
 */
var numIslands = function(grid) {
    if (grid.length < 1) {
        return 0;
    }
    
    const height = grid.length;
    const width = grid[0].length;
    let total = 0;

    for (let i = 0; i < grid.length; i++) {
    	for (let j = 0; j < grid[i].length; j++) {
    		if (grid[i][j] === '1') {
    			visit(grid, i, j, width, height);
    			total++;
    		}
    	}
    }

    return total;
};

var visit = function(grid, row, col, width, height) {
	let stack = [[row, col]];
	while (stack.length > 0) {
		var [i, j] = stack.pop();
		grid[i][j] = '0';

		if (i - 1 >= 0 && grid[i - 1][j] === '1') {
			stack.push([i-1, j]);
		}

		if (i + 1 < height && grid[i + 1][j] === '1') {
			stack.push([i + 1, j]);
		}

		if (j - 1 >= 0 && grid[i][j - 1] === '1') {
			stack.push([i, j - 1]);
		}

		if (j + 1 < width && grid[i][j + 1] === '1') {
			stack.push([i, j + 1]);
		}
	}
};

var dfsVisit = function(grid, row, col, width, height) {
    if (row < 0 || row >= height || col < 0 ||
        col >= width || grid[row][col] === '0') {
        return;
    }
	
    grid[row][col] = '0';
    dfsVisit(grid, row - 1, col, width, height);
    dfsVisit(grid, row + 1, col, width, height);
    dfsVisit(grid, row, col - 1, width, height);
    dfsVisit(grid, row, col + 1, width, height);
};
```