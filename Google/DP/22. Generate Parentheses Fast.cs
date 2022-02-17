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
            solution.GenerateParenthesis(3);
        }
    }

    public class Solution
    {
        private const string LeftParenthesis = "(";
        private const string RightParenthesis = ")";

        public IList<string> GenerateParenthesis(int n)
        {
            var list = new List<string>();
            GenerateParenthesisRecursively(n, n, list, string.Empty);

            return list;
        }

        public void GenerateParenthesisRecursively(int openCount, int closeCount, IList<string> result, string current)
        {
            if (openCount == 0 && closeCount == 0) result.Add(current);

            if (openCount > 0) GenerateParenthesisRecursively(openCount - 1, closeCount, result, current + LeftParenthesis);

            if (closeCount > openCount) GenerateParenthesisRecursively(openCount, closeCount - 1, result, current + RightParenthesis);
        }
    }
}
