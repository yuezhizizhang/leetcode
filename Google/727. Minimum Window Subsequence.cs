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
            solution.MinWindow("cnhczmccqouqadqtmjjzl", "mq");
        }
    }

    public class Solution
    {
        public string MinWindow(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1)
                || string.IsNullOrEmpty(s2)
                || s1.Length < s2.Length)
                    return string.Empty;

            var next = new int[s1.Length][];
            for (var i = 0; i < s1.Length; i++)
            {
                next[i] = new int[26];
                Array.Fill(next[i], -1);
            }

            for (var i = s1.Length - 2; i >= 0; i--)
            {
                for (var j = 0; j < 26; j++) next[i][j] = next[i + 1][j];

                var ch = s1[i + 1] - 'a';
                next[i][ch] = i + 1;
            }

            var startWith = s2[0];
            var starts = new List<int>();
            for (var i = 0; i < s1.Length; i++)
            {
                if (s1[i] == startWith)
                {
                    starts.Add(i);
                }
            }

            var startIndex = -1;
            var length = -1;
            foreach (var start in starts)
            {
                var end = start;
                var notFound = false;
                for (var i = 1; i < s2.Length; i++)
                {
                    end = next[end][s2[i] - 'a'];
                    if (end == -1)
                    {
                        notFound = true;
                        break;
                    }
                }

                if (notFound) continue;

                if (startIndex < 0 || end - start + 1 < length)
                {
                    startIndex = start;
                    length = end - start + 1;
                }
            }

            return startIndex < 0 ? string.Empty : s1.Substring(startIndex, length);
        }
    }
}
