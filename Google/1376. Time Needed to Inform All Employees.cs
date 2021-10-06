using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            var subordinates = new Dictionary<int, IList<int>>();
            for (var i = 0; i < manager.Length; i++)
            {
                var head = manager[i];
                if (head == -1) continue;

                if (subordinates.ContainsKey(head)) subordinates[head].Add(i);
                else subordinates.Add(head, new List<int> { i });
            }

            return TimeToInform(headID, subordinates, informTime);
        }

        public int TimeToInform(int head, IDictionary<int, IList<int>> subordinates, int[] informTime)
        {
            if (!subordinates.ContainsKey(head)) return 0;

            var time = informTime[head];
            var subs = subordinates[head];
            var maxTime = 0;
            foreach (var sub in subs)
            {
                maxTime = Math.Max(maxTime, time + TimeToInform(sub, subordinates, informTime));
            }

            return maxTime;
        }
    }
}
