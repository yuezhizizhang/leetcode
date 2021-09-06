using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "abb";
            var solutions = new Solution();
            solutions.LongestPalindrome(str);
        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            var longest = string.Empty;
            var max = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var result = FindLongestPalindrome(s, i, i, max);
                if (result != string.Empty)
                {
                    longest = result;
                    max = longest.Length;
                }

                result = FindLongestPalindrome(s, i, i + 1, max);
                if (result != string.Empty)
                {
                    longest = result;
                    max = longest.Length;
                }
            }

            return longest;
        }

        private string FindLongestPalindrome(string s, int l, int r, int max)
        {
            var longest = string.Empty;

            while (l >= 0 && r < s.Length)
            {
                if (s[l] != s[r])
                {
                    break;
                }

                var length = r - l + 1;
                if (length > max)
                {
                    longest = s.Substring(l, length);
                    max = length;
                }

                l--;
                r++;
            }

            return longest;
        }

        public string LongestPalindromeSlow(string s)
        {
            var charsMap = new Dictionary<char, IList<int>>();

            for (var i = 0; i < s.Length; i++)
            {
                var key = s[i];
                if (!charsMap.ContainsKey(key))
                {
                    charsMap[key] = new List<int>();
                }
                charsMap[key].Add(i);
            }

            var longest = $"{s[0]}";
            for (var start = 0; start < s.Length; start++)
            {
                var firstChar = s[start];
                var list = charsMap[firstChar];
                var index = list.IndexOf(start);
                for (var j = index + 1; j < list.Count; j++)
                {
                    var end = list[j];
                    var length = end - start + 1;
                    if (length > longest.Length && IsPalindrome(s, start, end))
                    {
                        longest = s.Substring(start, length);
                    }
                }
            }

            return longest;
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            if (start == end)
            {
                return true;
            }

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }
    }
}
