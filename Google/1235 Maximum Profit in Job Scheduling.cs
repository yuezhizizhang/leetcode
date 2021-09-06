using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            var length = startTime.Length;
            var jobs = new Job[length];

            for (var i = 0; i < length; i++)
            {
                jobs[i] = new Job
                {
                    StartTime = startTime[i],
                    EndTime = endTime[i],
                    Profit = profit[i],
                };
            }

            Array.Sort(jobs, new JobComparer());

            var startTimes = new int[length];
            for (var i = 0; i < length; i++)
            {
                startTimes[i] = jobs[i].StartTime;
            }

            var maxProfits = new int[length];
            for (var i = 0; i < length; i++)
            {
                maxProfits[i] = -1;
            }
            return FindMaxProfit(jobs, startTimes, maxProfits, length, 0);
        }

        private int FindMaxProfit(Job[] jobs, int[] startTimes, int[] maxProfits, int length, int position)
        {
            if (position >= length || position < 0)
            {
                return 0;
            }

            if (maxProfits[position] >= 0)
            {
                return maxProfits[position];
            }

            var job = jobs[position];
            var nextIndex = FindNextJob(startTimes, job.EndTime, position);

            var maxProfit = Math.Max(FindMaxProfit(jobs, startTimes, maxProfits, length, position + 1),
                job.Profit + FindMaxProfit(jobs, startTimes, maxProfits, length, nextIndex));
            maxProfits[position] = maxProfit;

            return maxProfit;
        }

        private int FindNextJob(int[] startTimes, int startTime, int startIndex)
        {
            var endIndex = startTimes.Length - 1;
            var nextIndex = startTimes.Length;

            while (startIndex <= endIndex)
            {
                var mid = (startIndex + endIndex) / 2;
                if (startTimes[mid] >= startTime)
                {
                    nextIndex = mid;
                    endIndex = mid - 1;
                }
                else
                {
                    startIndex = mid + 1;
                }
            }

            return nextIndex;
        }
    }

    class Job
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Profit { get; set; }
    }

    class JobComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((Job)x).StartTime - ((Job)y).StartTime;
        }
    }
}
