## 295. Find Median from Data Stream
https://leetcode.com/problems/find-median-from-data-stream/

> The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value and the median is the mean of the two middle values.
>   For example, for arr = [2,3,4], the median is 3.
>   For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
> Implement the MedianFinder class:
> * MedianFinder() initializes the MedianFinder object.
> * void addNum(int num) adds the integer num from the data stream to the data structure.
> * double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.
>
> Example 1:
> Input
>   ["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
>   [[], [1], [2], [], [3], []]
> Output
>   [null, null, null, 1.5, null, 2.0]
> Explanation
>   MedianFinder medianFinder = new MedianFinder();
>   medianFinder.addNum(1);    // arr = [1]
>   medianFinder.addNum(2);    // arr = [1, 2]
>   medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
>   medianFinder.addNum(3);    // arr[1, 2, 3]
>   medianFinder.findMedian(); // return 2.0

** Solution **

```C#
public class MedianFinder
{
    List<int> numbers;

    /** initialize your data structure here. */
    public MedianFinder()
    {
        numbers = new List<int>();
    }

    public void AddNum(int num)
    {
        var index = numbers.BinarySearch(num);

        if (index >= 0)
        {
            numbers.Insert(index, num);
        }
        else
        {
            numbers.Insert(~index, num);
        }
    }

    public double FindMedian()
    {
        var midIndex = numbers.Count / 2;

        if (numbers.Count % 2 == 0)
        {
            return (numbers[midIndex] + numbers[midIndex - 1]) / 2.0;
        }
        else
        {
            return numbers[midIndex];
        }
    }
}
```

```JavaScript
/**
 * initialize your data structure here.
 */
var MedianFinder = function() {
    this.minHeap = new Heap((a, b) => a - b);
    this.maxHeap = new Heap((a, b) => b - a);
};

/** 
 * @param {number} num
 * @return {void}
 */
MedianFinder.prototype.addNum = function(num) {
    this.maxHeap.add(num);
    this.minHeap.add(this.maxHeap.top);
    this.maxHeap.remove();

    if (this.minHeap.size > this.maxHeap.size) {
    	this.maxHeap.add(this.minHeap.top);
    	this.minHeap.remove();
    }
};

/**
 * @return {number}
 */
MedianFinder.prototype.findMedian = function() {
    let total = this.minHeap.size + this.maxHeap.size;
    if (total % 2 === 0) {
    	return (this.minHeap.top + this.maxHeap.top) / 2;
    } else {
    	return this.maxHeap.top;
    }
};

class Heap {
	constructor(comparer) {
		this.heap = [];
		this.size = 0;
		this.comparer = comparer;
	}

	get top() {
		if (this.size > 0) {
			return this.heap[0];
		}
		else {
			return undefined;
		}
	}

	add(num) {
		this.heap.push(num);
		this.size++;
		this.siftUp(this.size - 1);
	}

	remove() {
		let swap = this.heap.pop();
		this.size--;

		if (this.size < 1) {
			return;
		}

		this.heap[0] = swap;
		this.siftDown(0);
	}

	siftUp(index) {
		if (index < 1) {
			return;
		}

		let parent = Math.floor((index - 1) / 2);
		if (parent >= 0 && this.comparer(this.heap[index], this.heap[parent]) < 0) {
			let value = this.heap[index];
			this.heap[index] = this.heap[parent];
			this.heap[parent] = value;
			this.siftUp(parent);
		}
	}

	siftDown(index) {
		let leftChild = 2 * index + 1;
		let rightChild = 2 * index + 2;
		let swap = -1;

		if (rightChild >= this.size)
		{
			if (leftChild < this.size) {
				swap = leftChild;
			}
		} else {
			swap = this.comparer(this.heap[leftChild], this.heap[rightChild]) < 0
				? leftChild
				: rightChild;
		}

		if (swap > 0 && this.comparer(this.heap[swap], this.heap[index]) < 0) {
			let value = this.heap[index];
			this.heap[index] = this.heap[swap];
			this.heap[swap] = value;
			this.siftDown(swap);
		}
	}
}
```