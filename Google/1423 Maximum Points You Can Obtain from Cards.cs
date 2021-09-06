using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            if (k > cardPoints.Length || k < 1)
            {
                throw new ArgumentException();
            }

            var sum = 0;
            for (var i = 0; i < k; i++)
            {
                sum += cardPoints[i];
            }

            var max = sum;
            for (int i = k - 1, j = cardPoints.Length - 1; i >= 0; i--, j--)
            {
                sum = sum - cardPoints[i] + cardPoints[j];
                if (sum > max)
                {
                    max = sum;
                }
            }

            return max;
        }

        public int MaxScoreSlow(int[] cardPoints, int k)
        {
            if (k < 1 || cardPoints == null || cardPoints.Length < 1)
            {
                return 0;
            }

            var size = cardPoints.Length;
            var leftWindow = new int[k + 1];
            var rightWindow = new int[k + 1];
            var leftSum = 0;
            var rightSum = 0;
            for (var i = 0; i < k; i++)
            {
                if (i >= cardPoints.Length)
                {
                    break;
                }

                leftSum += cardPoints[i];
                rightSum += cardPoints[size - 1 - i];

                leftWindow[i + 1] = leftSum;
                rightWindow[i + 1] = rightSum; 
            }

            if (k >= size)
            {
                return leftWindow[leftWindow.Length - 1];
            }

            var max = 0;
            for (var i = 0; i <= k; i++)
            {
                var total = leftWindow[i] + rightWindow[k - i];
                if (total > max)
                {
                    max = total;
                }
            }

            return max;
        }
    }
}
