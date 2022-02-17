using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            if (grid.Length <= 0 || grid[0].Length <= 0) throw new ArgumentException();

            var height = grid.Length;
            var width = grid[0].Length;
            var max = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (grid[i][j] == 1) max = Math.Max(max, DfsVisit(grid, i, j, width, height));
                }
            }

            return max;
        }

        public int DfsVisit(int[][] grid, int row, int column, int width, int height)
        {
            if (grid[row][column] != 1) return 0;

            grid[row][column] = 0;

            var max = 1;

            // Top
            if (row - 1 >= 0 && grid[row - 1][column] == 1)
            {
                max += DfsVisit(grid, row - 1, column, width, height);
            }

            // Left
            if (column - 1 >= 0 && grid[row][column - 1] == 1)
            {
                max += DfsVisit(grid, row, column - 1, width, height);
            }

            // Right
            if (column + 1 < width && grid[row][column + 1] == 1)
            {
                max += DfsVisit(grid, row, column + 1, width, height);
            }

            // Bottom
            if (row + 1 < height && grid[row + 1][column] == 1)
            {
                max += DfsVisit(grid, row + 1, column, width, height);
            }

            return max;
        }
    }
}
