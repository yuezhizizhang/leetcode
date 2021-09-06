using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int FindLongestChain(int[][] pairs)
        {
            Array.Sort(pairs, new PairComparer());

            var length = pairs.Length;
            var longest = new int[length];
            for (var i = 0; i < length; i++)
            {
                longest[i] = -1;
            }

            return FindLongestChainFrom(pairs, longest, length, 0);
        }

        private int FindLongestChainFrom(int[][] pairs, int[] longest, int length, int position)
        {
            if (position >= length || position < 0)
            {
                return 0;
            }

            if (longest[position] != -1)
            {
                return longest[position];
            }

            int nextPosition = FindNextPair(pairs, pairs[position][1], position);

            var max = Math.Max(FindLongestChainFrom(pairs, longest, length, position + 1),
                1 + FindLongestChainFrom(pairs, longest, length, nextPosition));

            longest[position] = max;

            return max;
        }

        private int FindNextPair(int[][] pairs, int greater, int start)
        {
            int end = pairs.Length - 1;
            int nextPosition = pairs.Length;

            while (start <= end)
            {
                var mid = (start + end) / 2;
                if (pairs[mid][0] > greater)
                {
                    nextPosition = mid;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return nextPosition;
        }
    }

    class PairComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((int[])x)[0] - ((int[])y)[0];
        }
    }
}
