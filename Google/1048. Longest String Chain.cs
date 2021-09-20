using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.LongestStrChain(new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" });
        }
    }

    public class Solution
    {
        public int LongestStrChain(string[] words)
        {
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));

            var count = new int[words.Length];
            var max = 0;
            for (var i = 0; i < words.Length; i++)
            {
                max = Math.Max(max, Longest(words, count, i));
            }

            return max;
        }

        private int Longest(string[] words, int[] count, int start)
        {
            if (count[start] > 0) return count[start];

            var predecessor = words[start];
            var max = 1;

            for (var i = start + 1; i < words.Length; i++)
            {
                if (words[i].Length == predecessor.Length) continue;

                if (isPredecessor(predecessor, words[i]))
                {
                    max = Math.Max(max, 1 + Longest(words, count, i));
                }
            }

            count[start] = max;
            return max;
        }

        private bool isPredecessor(string predecessor, string word)
        {
            if (word.Length != predecessor.Length + 1) return false;

            var i = 0;
            var j = 0;
            var oneMismatch = false;
            while (i < predecessor.Length && j < word.Length)
            {
                if (predecessor[i] != word[j])
                {
                    if (oneMismatch) return false;
                    else j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }

            return i == predecessor.Length;
        }
    }
}
