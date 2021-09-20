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
            solution.NumSmallerByFrequency(new string[] { "bba", "abaaaaaa", "aaaaaa", "bbabbabaab", "aba", "aa", "baab", "bbbbbb", "aab", "bbabbaabb" }, 
                new string[] { "aaabbb", "aab", "babbab", "babbbb", "b", "bbbbbbbbab", "a", "bbbbbbbbbb", "baaabbaab", "aa" });
        }
    }

    public class Solution
    {
        private const int MaxLength = 10;

        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            var freqs = new int[MaxLength + 1];
            foreach (var word in words)
            {
                ++freqs[CalcFrequency(word)];
            }

            for (var i = freqs.Length - 2; i > 0; i--)
            {
                freqs[i] += freqs[i + 1];
            }

            var result = new int[queries.Length];
            for (var i = 0; i < queries.Length; i++)
            {
                var count = CalcFrequency(queries[i]);
                result[i] = count >= MaxLength ? 0 : freqs[count + 1];
            }

            return result;
        }

        private int CalcFrequency(string word)
        {
            char min = word.Min();
            return word.Count(c => c == min);
        }

        public int[] NumSmallerByFrequencySlow(string[] queries, string[] words)
        {
            if (words.Length < 1 || queries.Length < 1)
            {
                throw new ArgumentException();
            }

            var freqs = new int[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                freqs[i] = Frequency(words[i]);
            }

            Array.Sort(freqs);

            var result = new int[queries.Length];
            for (var i = 0; i < queries.Length; i++)
            {
                var f = Frequency(queries[i]);
                result[i] = BinarySearch(freqs, f);
            }

            return result;
        }

        private int Frequency(string word)
        {
            if (string.IsNullOrEmpty(word)) return 0;

            var ch = word[0];
            var count = 1;
            for (var i = 1; i < word.Length; i++)
            {
                if (word[i] < ch)
                {
                    ch = word[i];
                    count = 1;
                }
                else if (word[i] == ch)
                {
                    count++;
                }
            }

            return count;
        }

        private int BinarySearch(int[] nums, int search)
        {
            var start = 0;
            var end = nums.Length - 1;

            if (nums[end] <= search) return 0;
            if (nums[start] > search) return nums.Length;

            while (start < end)
            {
                var mid = (start + end) / 2;
                if (nums[mid] > search) end = mid;
                else start = mid + 1;
            }

            return nums.Length - end;
        }
    }
}
