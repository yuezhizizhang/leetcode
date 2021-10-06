using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int CountSquares(int[][] matrix)
        {
            var height = matrix.Length;
            var total = 0;
            for (var i = 0; i < height; i++)
            {
                var width = matrix[i].Length;
                for (var j = 0; j < width; j++)
                {
                    if (matrix[i][j] == 0) continue;

                    if (i == 0 || j == 0)
                    {
                        total++;
                        continue;
                    }

                    var count = Math.Min(matrix[i][j - 1], Math.Min(matrix[i - 1][j - 1], matrix[i - 1][j]));
                    matrix[i][j] = count + 1;
                    total += matrix[i][j];
                }
            }

            return total;
        }

        public int CountSquaresSlow(int[][] matrix)
        {
            var height = matrix.Length;
            for (var i = 0; i < height; i++)
            {
                var width = matrix[i].Length;
                for (var j = 0; j < width; j++)
                {
                    if (matrix[i][j] == 0) continue;

                    CountSquaresEndingAt(matrix, i, j, 1);
                }
            }

            var total = 0;
            for (var i = 0; i < height; i++)
            {
                var width = matrix[i].Length;
                for (var j = 0; j < width; j++)
                {
                    total += matrix[i][j];
                }
            }

            return total;
        }

        private void CountSquaresEndingAt(int[][] matrix, int row, int column, int size)
        {
            if (row - size < 0 || column - size < 0) return;

            var topRow = row - size;
            var leftColumn = column - size;

            for (var j = leftColumn; j <= column; j++)
            {
                if (matrix[topRow][j] == 0) return;
            }

            for (var i = topRow; i <= row; i++)
            {
                if (matrix[i][leftColumn] == 0) return;
            }

            matrix[topRow][leftColumn] += 1;
            CountSquaresEndingAt(matrix, row, column, ++size);
        }
    }
}
