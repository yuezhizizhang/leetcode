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

let finder = new MedianFinder();
finder.addNum(1);
finder.addNum(2);
let value = finder.findMedian();
finder.addNum(3);
value = finder.findMedian();