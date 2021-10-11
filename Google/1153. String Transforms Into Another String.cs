using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public bool CanConvert(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length) return false;

            var map = new Dictionary<char, char>();
            var changed = 0;
            var swap = false;
            var chars = new HashSet<char>();
            for (var i = 0; i < str1.Length; i++)
            {
                var key = str1[i];
                var value = str2[i];

                if (!map.ContainsKey(key))
                {
                    map.Add(key, value);

                    if (key != value)
                    {
                        changed++;
                        if (!swap && map.ContainsKey(value) && map[value] == key) swap = true;
                    }
                }
                else if (map[key] != value)
                {
                    return false;
                }

                if (!chars.Contains(value)) chars.Add(value);
            }

            return chars.Count < 26 || (changed < 26 && !swap);
        }
    }
}
