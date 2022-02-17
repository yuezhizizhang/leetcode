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
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length <= 0) return 0;

            var rows = matrix.Length;
            var columns = matrix[0].Length;
            var dp = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                dp[i] = new int[columns];
            }

            var max = 0;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    max = Math.Max(max, CalculateLongestPath(i, j, rows, columns, matrix, dp));
                }
            }

            return max;
        }

        private int CalculateLongestPath(int row, int column, int rows, int columns, int[][] matrix, int[][] dp)
        {
            if (dp[row][column] != 0) return dp[row][column];

            var max = 0;

            // Top
            if (row - 1 >= 0 && matrix[row][column] < matrix[row - 1][column])
            {
                max = Math.Max(max, CalculateLongestPath(row - 1, column, rows, columns, matrix, dp));
            }

            // Left
            if (column - 1 >= 0 && matrix[row][column] < matrix[row][column - 1])
            {
                max = Math.Max(max, CalculateLongestPath(row, column - 1, rows, columns, matrix, dp));
            }

            // Right
            if (column + 1 < columns && matrix[row][column] < matrix[row][column + 1])
            {
                max = Math.Max(max, CalculateLongestPath(row, column + 1, rows, columns, matrix, dp));
            }

            // Bottom
            if (row + 1 < rows && matrix[row][column] < matrix[row + 1][column])
            {
                max = Math.Max(max, CalculateLongestPath(row + 1, column, rows, columns, matrix, dp));
            }

            dp[row][column] = ++max;
            return max;
        }
    }
}
