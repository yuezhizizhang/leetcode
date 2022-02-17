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
            var size = n + 1;
            var dp = new IList<string>[size][];
            for (var i = 0; i < size; i++)
            {
                dp[i] = new IList<string>[size];
            }
            return GenerateParenthesisRecursively(n, n, dp);
        }

        public IList<string> GenerateParenthesisRecursively(int left, int right, IList<string>[][] dp)
        {
            if (left == 0 && right == 0) return new List<string> { string.Empty };

            if (dp[left][right] != null) return dp[left][right];

            var list = new List<string>();
            if (left > 0)
            {
                var result = GenerateParenthesisRecursively(left - 1, right, dp);
                foreach (var str in result) list.Add(string.Concat(LeftParenthesis, str));
            }

            if (right > 0 && right > left)
            {
                var result = GenerateParenthesisRecursively(left, right - 1, dp);
                foreach (var str in result) list.Add(string.Concat(RightParenthesis, str));
            }

            dp[left][right] = list;
            return list;
        }
    }
}
