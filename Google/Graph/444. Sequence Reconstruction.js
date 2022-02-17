/**
 * @param {number[]} nums
 * @param {number[][]} sequences
 * @return {boolean}
 */
var sequenceReconstruction = function(nums, sequences) {
    if (nums.length <= 0) return false;

    const size = nums.length + 1;
    let adjacencyList = new Array(size);
    let indegrees = new Array(size).fill(0);
    if (buildGraph(sequences, adjacencyList, indegrees) !== nums.length) return false;

    let queue = [];
    for (let i = 0; i < indegrees.length; i++) {
    	if (indegrees[i] === 0) queue.push(i);
    }

    let index = 0;
    while (queue.length > 0) {
    	if (queue.length !== 1) return false;

    	const node = queue.pop();
    	if (node !== nums[index++]) return false;

    	for (const n of adjacencyList[node]) {
    		if (--indegrees[n] === 0) queue.push(n);
    	}
    }

    return index === nums.length;
};

var buildGraph = function(sequences, adjacencyList, indegrees) {
	let numberOfVertices = 0;

	for (let list of sequences) {
		for (let i = 0; i < list.length; i++) {
			const node = list[i];

			if (adjacencyList[node] === undefined) {
				adjacencyList[node] = [];
				numberOfVertices++;
			}

			if (i + 1 < list.length) {
				const next = list[i + 1];
				adjacencyList[node].push(next);
				indegrees[next]++;
			}
		}
	}

	return numberOfVertices;
};