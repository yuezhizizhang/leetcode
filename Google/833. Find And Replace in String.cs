using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            if (indices.Length != sources.Length || indices.Length != targets.Length)
            {
                throw new ArgumentException();
            }

            var size = indices.Length;
            var replaces = new Replace[size];
            for (var i = 0; i < size; i++)
            {
                replaces[i] = new Replace
                {
                    Index = indices[i],
                    Source = sources[i],
                    Target = targets[i],
                };
            }

            Array.Sort(replaces, (r1, r2) => r1.Index.CompareTo(r2.Index));

            var sb = new StringBuilder();
            var start = 0;
            foreach (var replace in replaces)
            {
                var index = replace.Index;

                for (var i = start; i < index; i++) sb.Append(s[i]);
                start = index;

                if (!IsStartWith(s, index, replace.Source)) continue;

                sb.Append(replace.Target);
                start += replace.Source.Length;
            }

            while (start < s.Length) sb.Append(s[start++]);

            return sb.ToString();
        }

        private bool IsStartWith(string s, int start, string substr)
        {
            var end = start + substr.Length;
            if (end > s.Length) return false;

            for (int i = start, j = 0; i < end; i++, j++)
            {
                if (s[i] != substr[j]) return false;
            }

            return true;
        }

        public string FindReplaceStringSlow(string s, int[] indices, string[] sources, string[] targets)
        {
            if (indices.Length != sources.Length || indices.Length != targets.Length)
            {
                throw new ArgumentException();
            }

            var size = indices.Length;
            var replaces = new Replace[size];
            for (var i = 0; i < size; i++)
            {
                replaces[i] = new Replace
                {
                    Index = indices[i],
                    Source = sources[i],
                    Target = targets[i],
                };
            }

            Array.Sort(replaces, (r1, r2) => r1.Index.CompareTo(r2.Index));

            var sb = new StringBuilder();
            var start = 0;
            foreach (var replace in replaces)
            {
                var index = replace.Index;

                if (index + replace.Source.Length > s.Length) continue;
                if (!s.Substring(index, replace.Source.Length).Equals(replace.Source)) continue;

                if (index > start) sb.Append(s.Substring(start, index - start));
                start = index + replace.Source.Length;

                sb.Append(replace.Target);
            }

            if (start < s.Length) sb.Append(s.Substring(start));

            return sb.ToString();
        }
    }

    public class Replace
    {
        public int Index { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }
}
