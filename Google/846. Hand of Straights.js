/**
 * @param {number[]} hand
 * @param {number} groupSize
 * @return {boolean}
 */
var isNStraightHand = function(hand, groupSize) {
	if (hand.length % groupSize !== 0) {
    	return false;
    }

    let counter = new Map();
    for (let num of hand) {
    	if (counter.has(num)) {
    		counter.set(num, counter.get(num) + 1);
    	} else {
    		counter.set(num, 1);
    	}
    }

    let sorted = [...counter.keys()].sort((a, b) => a - b);
    for (let num of sorted) {
    	let cnt = counter.get(num);

    	if (cnt === 0) continue;

    	for (let i = 1; i < groupSize; i++) {
    		let next = num + i;

    		if (!counter.has(next) || counter.get(next) < cnt) {
    			return false;
    		}

    		counter.set(next, counter.get(next) - cnt);
    	}
    }

    return true;
};

isNStraightHand([1,2,3,6,2,3,4,7,8], 3);