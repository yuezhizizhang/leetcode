using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var start = 0;
            var max = 1;
            var total = 1;
            var charsMap = new Dictionary<char, int>
            {
                { s[0], 0 },
            };

            for (var j = 1; j < s.Length; j++)
            {
                var key = s[j];
                if (charsMap.ContainsKey(key) && charsMap[key] >= start)
                {
                    max = Math.Max(max, total);
                    start = charsMap[key] + 1;
                    total = j - start;
                }

                charsMap[key] = j;
                total++;
            }

            max = Math.Max(max, total);

            return max;
        }
    }


}
