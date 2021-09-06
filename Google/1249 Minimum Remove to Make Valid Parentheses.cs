using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        private const char RightBracket = ')';
        private const char LeftBracket = '(';

        public string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<int>();
            var set = new HashSet<int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == LeftBracket)
                {
                    stack.Push(i);
                }
                else if (s[i] == RightBracket)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        set.Add(i);
                    }
                }
            }

            set.UnionWith(stack);

            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (!set.Contains(i))
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
    }
}
