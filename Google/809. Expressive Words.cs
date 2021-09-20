using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            solution.ExpressiveWords("vvvppppeeezzzzztttttkkkkkkugggggbbffffffywwwwwwbbbccccddddddkkkkksssppppddpzzzzzhhhhbbbbbmmmy",
                new string[] { "vvpeezztkkugbbffywwbccdkkspddpzzhbmmyy" });
        }
    }

    public class Solution
    {
        public int ExpressiveWords(string s, string[] words)
        {
            var counter = new List<KeyValuePair<char, int>>();
            Group(s, counter);

            var total = 0;
            foreach (var word in words)
            {
                if (word.Length < counter.Count || word.Length > s.Length) continue;

                if (IsStrechy(word, counter)) total++;
            }

            return total;
        }

        private void Group(string s, IList<KeyValuePair<char, int>> counter)
        {
            var start = 0;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == s[start]) continue;

                var count = i - start;
                if (count == 2)
                {
                    counter.Add(new KeyValuePair<char, int>(s[start], 1));
                    counter.Add(new KeyValuePair<char, int>(s[start], 1));
                }
                else
                {
                    counter.Add(new KeyValuePair<char, int>(s[start], count));
                }

                start = i;
            }

            if (start < s.Length)
            {
                var count = s.Length - start;
                if (count == 2)
                {
                    counter.Add(new KeyValuePair<char, int>(s[start], 1));
                    counter.Add(new KeyValuePair<char, int>(s[start], 1));
                }
                else
                {
                    counter.Add(new KeyValuePair<char, int>(s[start], count));
                }
            }
        }

        private bool IsStrechy(string word, IList<KeyValuePair<char, int>> counter)
        {
            var pos = 0;
            var i = 0;
            while (i < word.Length && pos < counter.Count)
            {
                var (ch, cnt) = counter[pos];

                if (word[i] != ch)
                {
                    return false;
                }

                if (cnt > 1)
                {
                    var left = i;
                    while (++i < word.Length && word[i] == word[left]) { }

                    if (i - left > cnt)
                    {
                        return false;
                    }

                    pos++;
                }
                else
                {
                    i++;
                    pos++;
                }
            }

            return i >= word.Length;
        }
    }
}
