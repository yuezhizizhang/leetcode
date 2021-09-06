/**
 * @param {number[]} nums
 * @param {number} limit
 * @return {number}
 */
var longestSubarray = function(nums, limit) {
    let max = new LinkedList();
    let min = new LinkedList();
    let left = 0;
    let right = 0;

    while (right < nums.length) {
    	let num = nums[right++];
    	while (max.count > 0 && max.last.value < num) max.removeLast();
    	while (min.count > 0 && min.last.value > num) min.removeLast();

    	max.addLast(num);
    	min.addLast(num);

    	if (max.first.value - min.first.value <= limit) continue;

    	num = nums[left++];
    	if (max.first.value === num) max.removeFirst();
    	if (min.first.value === num) min.removeFirst();
    }

    return right - left;
};

class LinkedList {
	constructor() {
		this.head = null;
		this.tail = null;
		this.count = 0;
	}

	get first() {
		return this.head;
	}

	get last() {
		return this.tail;
	}

	addLast(num) {
		let node = new Node(num);

		if (!!this.tail) {
			this.tail.next = node;
			node.previous = this.tail;
		}

		this.count++;
		this.tail = node;
		if (!this.head) {
			this.head = node;
		}
	}

	removeLast() {
		if (this.count < 1) {
			return;
		}

		if (this.count === 1) {
			this.head = this.tail = null;
		} else {
			this.tail = this.tail.previous;
			this.tail.next = null;
		}
		this.count--;
	}

	removeFirst() {
		if (this.count < 1) {
			return;
		}

		if (this.count === 1) {
			this.head = this.tail = null;
		} else {
			let node = this.head.next;
			node.previous = null;
			this.head.next = null;
			this.head = node;
		}
		this.count--;
	}
}

class Node {
	constructor(value, next = null, previous = null) {
		this.value = value;
		this.next = next;
		this.previous = previous;
	}
}

longestSubarray([8, 2, 4, 7], 4);