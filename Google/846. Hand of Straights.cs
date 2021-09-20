using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            solution.IsNStraightHand(new int[] { 1, 2, 3, 5, 5, 6, 7 }, 3);
        }
    }

    public class Solution
    {
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0) return false;

            Array.Sort(hand);

            var counter = new Dictionary<int, int>();
            foreach (var num in hand)
            {
                if (counter.ContainsKey(num))
                    counter[num]++;
                else
                    counter[num] = 1;
            }

            foreach (var num in hand)
            {
                if (counter[num] == 0) continue;

                counter[num]--;
                for (var i = 1; i < groupSize; i++)
                {
                    var value = num + i;
                    if (counter.ContainsKey(value) && counter[value] > 0)
                        counter[value]--;
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
