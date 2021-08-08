using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = { new int[] { 0, 1, 0, 1, 1 }, new int[] { 1, 1, 0, 0, 1 }, new int[] { 0, 0, 0, 1, 0 }, new int[] { 1, 0, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 1 } };
            var result = UpdateMatrix(mat);
        }

        public static int[][] UpdateMatrix(int[][] mat)
        {
            var visitedCells = new Queue<(int, int)>();

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        visitedCells.Enqueue((i, j));
                    }
                    else
                    {
                        mat[i][j] = int.MaxValue;
                    }
                }
            }

            while (visitedCells.Count > 0)
            {
                var (row, column) = visitedCells.Dequeue();
                var value = mat[row][column] + 1;

                // top cell
                if (row - 1 >= 0 && mat[row - 1][column] > value)
                {
                    mat[row - 1][column] = value;
                    visitedCells.Enqueue((row - 1, column));
                }

                // bottom cell
                if (row + 1 < mat.Length && mat[row + 1][column] > value)
                {
                    mat[row + 1][column] = value;
                    visitedCells.Enqueue((row + 1, column));
                }

                // left cell
                if (column - 1 >= 0 && mat[row][column - 1] > value)
                {
                    mat[row][column - 1] = value;
                    visitedCells.Enqueue((row, column - 1));
                }

                // rigth cell
                if (column + 1 < mat[row].Length && mat[row][column + 1] > value)
                {
                    mat[row][column + 1] = value;
                    visitedCells.Enqueue((row, column + 1));
                }
            }

            return mat;
        }
    }
}
