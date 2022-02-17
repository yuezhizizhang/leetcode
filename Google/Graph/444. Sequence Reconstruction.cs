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
        public bool SequenceReconstruction(int[] nums, IList<IList<int>> sequences)
        {
            var size = nums.Length + 1;
            var graph = new IList<int>[size];
            var indegrees = new int[size];
            
            if (GenerateGraph(graph, indegrees, sequences) != nums.Length) return false;

            var topVertices = new Queue<int>();
            for (var i = 1; i < size; i++)
            {
                if (indegrees[i] == 0) topVertices.Enqueue(i);
            }

            var index = 0;
            while (topVertices.Count > 0)
            {
                if (topVertices.Count > 1) return false;

                var vertice = topVertices.Dequeue();

                if (nums[index++] != vertice) return false;

                for (var i = 0; i < graph[vertice].Count; i++)
                {
                    var node = graph[vertice][i];
                    if (--indegrees[node] == 0) topVertices.Enqueue(node);
                }
            }

            return index == nums.Length;
        }

        private int GenerateGraph(IList<int>[] graph, int[] indegrees, IList<IList<int>> sequences)
        {
            var numberOfVertices = 0;

            for (var i = 0; i < sequences.Count; i++)
            {
                for (var j = 0; j < sequences[i].Count; j++)
                {
                    var vertice = sequences[i][j];

                    if (graph[vertice] == null)
                    {
                        graph[vertice] = new List<int>();
                        numberOfVertices++;
                    }

                    if (j + 1 < sequences[i].Count)
                    {
                        graph[vertice].Add(sequences[i][j + 1]);
                        indegrees[sequences[i][j + 1]]++;
                    }
                }
            }

            return numberOfVertices;
        }
    }
}
