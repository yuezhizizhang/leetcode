## 1235. Maximum Profit in Job Scheduling
https://leetcode.com/problems/maximum-profit-in-job-scheduling/

> We have n jobs, where every job is scheduled to be done from startTime[i] to endTime[i], obtaining a profit of profit[i].
> You're given the startTime, endTime and profit arrays, return the maximum profit you can take such that there are no two jobs in the subset with overlapping time range.
> If you choose a job that ends at time X you will be able to start another job that starts at time X.
>
> Example 1:
>   Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
>   Output: 120
>   Explanation: The subset chosen is the first and fourth job. 
>   Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.
>
> Example 2:
>   Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit = [20,20,100,70,60]
>   Output: 150
>   Explanation: The subset chosen is the first, fourth and fifth job. 
>   Profit obtained 150 = 20 + 70 + 60.
>
> Example 3:
>   Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
>   Output: 6
>
> Constraints:
> * 1 <= startTime.length == endTime.length == profit.length <= 5 * 104
> * 1 <= startTime[i] < endTime[i] <= 109
> * 1 <= profit[i] <= 104

** Solution **

1. Store the startTime, endTime and profit of each job in jobs.
2. Sort the jobs according to their starting time.
3. Iterate over jobs from left to right, where position is the index of the current job. For each job, we must compare two options:
   i. Skip the current job (earn 0 profit) and move on to consider the job at the index position + 1.
   ii. Schedule the current job (earn profit for the current job) and move on to the next non-conflicting job whose index is nextIndex. nextIndex is determined by using binary search in the startTime array.
4. Return the maximum profit of the two choices and record this profit in the array memo (memoization).

```C#
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
        if (position >= length)
        {
            return 0;
        }

        if (maxProfits[position] != -1)
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
```

```JavaScript
/**
 * @param {number[]} startTime
 * @param {number[]} endTime
 * @param {number[]} profit
 * @return {number}
 */
var jobScheduling = function(startTime, endTime, profit) {
    let length = startTime.length;

    let jobs = [];
    for (let i = 0; i < length; i++)
    {
    	jobs.push({
    		startTime: startTime[i],
    		endTime: endTime[i],
    		profit: profit[i]
    	});
    }

    jobs.sort((a, b) => a.startTime - b.startTime);

    let maxProfits = new Array(length);
    return findMaxProfit(jobs, maxProfits, length, 0);
};

var findMaxProfit = function(jobs, maxProfits, length, position) {
	if (position >= length || position < 0) {
		return 0;
	}

	if (maxProfits[position] !== undefined) {
		return maxProfits[position];
	}

	let job = jobs[position];
	let nextIndex = findNextJob(jobs, job.endTime, position);

	let maxProfit = Math.max(findMaxProfit(jobs, maxProfits, length, position + 1),
		job.profit + findMaxProfit(jobs, maxProfits, length, nextIndex));

	maxProfits[position] = maxProfit;

	return maxProfit;
};

var findNextJob = function(jobs, startTime, start) {
	let end = jobs.length - 1;
	let nextIndex = jobs.length;

	while (start <= end) {
		let mid = Math.floor((start + end) / 2);

		if (jobs[mid].startTime >= startTime) {
			nextIndex = mid;
			end = mid - 1;
		} else {
			start = mid + 1;
		}
	}

	return nextIndex;
}
```