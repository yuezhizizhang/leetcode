using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            var length = pushed.Length;
            var stack = new Stack<int>();
            var curr = 0;
            for (var i = 0; i < length; i++)
            {
                stack.Push(pushed[i]);
                while (stack.Count > 0 && curr < length && stack.Peek() == popped[curr])
                {
                    stack.Pop();
                    curr++;
                }
            }

            return curr == length;
        }

        public bool ValidateStackSequencesSlow(int[] pushed, int[] popped)
        {
            var positions = new Dictionary<int, int>();
            for (var i = 0; i < pushed.Length; i++)
            {
                positions.Add(pushed[i], i);
            }

            var visited = new bool[pushed.Length];
            var curr = -1;
            for (var i = 0; i < popped.Length; i++)
            {
                var key = popped[i];
                var pos = positions[key];
                if (visited[pos])
                {
                    return false;
                }

                if (pos < curr && !IsInSequence(visited, curr, pos))
                {
                    return false;
                }

                curr = pos;
                visited[pos] = true;
            }

            return true;
        }

        private bool IsInSequence(bool[] visited, int right, int left)
        {
            for (var i = right - 1; i > left; i--)
            {
                if (!visited[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
