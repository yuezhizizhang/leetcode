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
            solution.UniqueLetterString("ABC");
        }
    }

    public class Solution
    {
        private const char A = 'A';

        public int UniqueLetterString(string s)
        {
            var count = 0;

            var occurs1 = new int[26];
            Array.Fill(occurs1, -1);
            var occurs2 = new int[26];
            Array.Fill(occurs2, -1);

            for (var i = 0; i < s.Length; i++)
            {
                var ch = s[i] - A;
                count += (occurs2[ch] - occurs1[ch]) * (i - occurs2[ch]);
                occurs1[ch] = occurs2[ch];
                occurs2[ch] = i;
            }

            var current = s.Length;
            for (var i = 0; i < occurs2.Length; i++)
            {
                if (occurs2[i] < 0) continue;

                count += (occurs2[i] - occurs1[i]) * (current - occurs2[i]);
            }

            return count;
        }
    }
}
