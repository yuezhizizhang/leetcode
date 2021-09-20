/**
 * @param {number[]} nums
 * @return {boolean}
 */
var isPossible = function(nums) {
    let counter = {};
    for (let num of nums) {
        if (counter.hasOwnProperty(num)) {
            counter[num]++;
        } else {
            counter[num] = 1;
        }
    }

    let ends = {};
    for (let num of nums) {
        if (counter[num] === 0) continue;

        counter[num]--;
        if (ends.hasOwnProperty(num) && ends[num] > 0) {
            ends[num]--;

            let next = num + 1;
            if (ends.hasOwnProperty(next)) {
                ends[next]++;
            } else {
                ends[next] = 1;
            }
        } else {
            let incr = 1;
            while (incr < 3) {
                let next = num + incr++;
                if (counter.hasOwnProperty(next) && counter[next] > 0) {
                    counter[next]--;
                } else {
                    return false;
                }
            }

            let value = num + incr;
            if (ends.hasOwnProperty(value)) {
                ends[value]++;
            } else {
                ends[value] = 1;
            }
        }
    }

    return true;
};