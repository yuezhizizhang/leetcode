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
            var solution = new Solution();
            solution.MostSimilar(
                5,
                new int[6][] { new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 2, 4 } },
                new string[] { "ATL", "PEK", "LAX", "DXB", "HND" },
                new string[] { "ATL", "DXB", "HND", "LAX" }
            );
        }
    }

    public class Solution
    {
        public IList<int> MostSimilar(int n, int[][] roads, string[] names, string[] targetPath)
        {
            if (n != names.Length) throw new ArgumentException("The number of vertices is wrong.");

            // Edges
            var edges = new IList<int>[n];
            for (var i = 0; i < n; i++)
            {
                edges[i] = new List<int>();
            }
            foreach (var pair in roads)
            {
                var n1 = pair[0];
                var n2 = pair[1];
                edges[n1].Add(n2);
                edges[n2].Add(n1);
            }

            var dp = new PathEdit[n][];
            for (var i = 0; i < n; i++)
            {
                dp[i] = new PathEdit[targetPath.Length];
            }

            PathEdit minEdit = null;
            for (var i = 0; i < n; i++)
            {
                var edit = FindMinimumEdits(i, 0, dp, names, targetPath, edges);

                if (minEdit == null || edit.Edits < minEdit.Edits) minEdit = edit;

                if (minEdit.Edits == 0) break;
            }

            return minEdit.Path;
        }

        private PathEdit FindMinimumEdits(int v, int t, PathEdit[][] dp, string[] names, string[] targetPath, IList<int>[] edges)
        {
            if (dp[v][t] != null) return dp[v][t];

            if (t == targetPath.Length - 1)
            {
                var edit = new PathEdit()
                {
                    Path = new List<int> { v },
                    Edits = names[v] == targetPath[t] ? 0 : 1,
                };

                dp[v][t] = edit;
                return edit;
            }

            var connects = edges[v];
            PathEdit minEdit = null;
            foreach (var n in connects)
            {
                var edit = FindMinimumEdits(n, t + 1, dp, names, targetPath, edges);

                if (minEdit == null || edit.Edits < minEdit.Edits) minEdit = edit;
            }

            PathEdit pathEdit = new PathEdit();
            pathEdit.Edits = minEdit.Edits + (names[v] == targetPath[t] ? 0 : 1);
            pathEdit.Path = new List<int> { v };
            pathEdit.Path.AddRange(minEdit.Path);
            dp[v][t] = pathEdit;
            return pathEdit;
        }

        private class PathEdit
        {
            public int Edits { get; set; }
            public List<int> Path { get; set; }
        }
    }
}
