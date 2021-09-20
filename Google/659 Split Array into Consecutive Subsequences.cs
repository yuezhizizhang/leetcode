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
            solution.IsPossible(new int[] { 1, 2, 3, 5, 5, 6, 7 });
        }
    }

    public class Solution
    {
        public bool IsPossible(int[] nums)
        {
            var counter = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (counter.ContainsKey(num))
                    counter[num]++;
                else
                    counter[num] = 1;
            }

            var ends = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (counter[num] < 1) continue;

                counter[num]--;
                if (ends.ContainsKey(num))
                {
                    if (--ends[num] == 0) ends.Remove(num);

                    this.AddEnds(ends, num + 1);
                }
                else
                {
                    var i = 1;
                    while (i < 3)
                    {
                        var next = num + i++;
                        if (counter.ContainsKey(next) && counter[next] > 0)
                            counter[next]--;
                        else
                            return false;
                    }

                    this.AddEnds(ends, num + i);
                }
            }

            return true;
        }

        private void AddEnds(Dictionary<int, int> ends, int key)
        {
            if (ends.ContainsKey(key))
                ends[key]++;
            else
                ends.Add(key, 1);
        }
    }
}
