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
        private const char Land = '1';
        private const char Water = '0';

        public int NumIslands(char[][] grid)
        {
            if (grid.Length <= 0 || grid[0].Length <= 0) throw new ArgumentException();

            var count = 0;
            var height = grid.Length;
            var width = grid[0].Length;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (grid[i][j] == Land)
                    {
                        count++;
                        DfsVisit(grid, i, j, height, width);
                    }
                }
            }

            return count;
        }

        public void DfsVisit(char[][] grid, int row, int column, int height, int width)
        {
            if (grid[row][column] != Land) return;

            grid[row][column] = Water;

            // Top
            if (row - 1 >= 0 && grid[row - 1][column] == Land)
            {
                DfsVisit(grid, row - 1, column, height, width);
            }

            // Bottom
            if (row + 1 < height && grid[row + 1][column] == Land)
            {
                DfsVisit(grid, row + 1, column, height, width);
            }

            // Left
            if (column - 1 >= 0 && grid[row][column - 1] == Land)
            {
                DfsVisit(grid, row, column - 1, height, width);
            }

            // Right
            if (column + 1 < width && grid[row][column + 1] == Land)
            {
                DfsVisit(grid, row, column + 1, height, width);
            }
        }
    }
}
