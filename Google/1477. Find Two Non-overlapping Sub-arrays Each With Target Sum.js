/**
 * @param {number[]} arr
 * @param {number} target
 * @return {number}
 */
var minSumOfLengths = function(arr, target) {
    if (!arr || arr.length === 0) return -1;

    const size = arr.length;

    let start = 0;
    let end = 0;
    let sum = 0;
    let windows = new Map();
    while (end < size) {
        sum += arr[end++];

        if (sum > target) {
            do {
                sum -= arr[start++];
            } while (sum > target)
        }

        if (sum === target) {
            windows.set(start, {start: start, end: end, length: end - start});
            sum -= arr[start++];
        }
    }

    let maxLengths = new Array(size);
    maxLengths.fill(-1);
    for (let i = size - 1; i >= 0; i--) {
        if (i < size - 1) maxLengths[i] = maxLengths[i + 1];

        if (windows.has(i)) {
            const length = windows.get(i).length;
            if (maxLengths[i] < 0 || length < maxLengths[i]) maxLengths[i] = length;
        }
    }

    let max = -1;
    for (let window of windows.values()) {
        if (window.end >= size || maxLengths[window.end] < 0) continue;

        const length = window.length + maxLengths[window.end];
        if (max < 0 || length < max) max = length;
    }

    return max;
};

minSumOfLengths([1,6,1], 7);