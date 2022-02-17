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
            if (string.IsNullOrEmpty(s)) return 0;

            const int rows = 'Z' - A + 1;
            var freq = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                freq[i] = new int[s.Length];
            }

            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (i + 1 < s.Length)
                {
                    for (var j = 0; j < rows; j++) freq[j][i] = freq[j][i + 1];
                }

                var letter = s[i] - A;
                freq[letter][i] = i + 1 < s.Length ? freq[letter][i + 1] + 1 : 1;
            }

            return UniqueLetterInSubstringON2(s.Length - 1, s, freq);
        }

        private int UniqueLetterInSubstringON2(int pos, string s, int[][] freq)
        {
            if (pos < 0) return 0;

            var sum = 1;
            var pre = 1;
            for (var i = pos - 1; i >= 0; i--)
            {
                var key = s[i] - A;
                var count = pos + 1 < s.Length ? freq[key][i] - freq[key][pos + 1] : freq[key][i];

                if (count == 1) pre++;
                if (count == 2) pre--;

                sum += pre;
            }

            return sum + UniqueLetterInSubstringON2(--pos, s, freq);
        }
    }
}
