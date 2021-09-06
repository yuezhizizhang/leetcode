using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            var bracketPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }, 
            };

            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                var key = s[i];
                if (bracketPairs.ContainsKey(key))
                {
                    stack.Push(key);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var top = stack.Pop();
                    if (key != bracketPairs[top])
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
