/**
 * @param {number} n
 * @return {number}
 */
var confusingNumberII = function(n) {
    const validConfusingDigits = [1, 6, 8, 9];

    if (n < 6) return 0;
    if (n < 9) return 1;
    if (n < 10) return 2;

    let count = 2;
    let multiply = 1;
    let nums = [0, 1, 6, 8, 9];
    let temp = [];
    while (true) {
        const length = nums.length;
        multiply *= 10;
        for (const d of validConfusingDigits) {
            const add = d * multiply;
            for (let i = 0; i < length; i ++) {
                const sum = add + nums[i];
                if (sum > n) return count;

                nums.push(sum);
                if (isConfusingNumber(sum)) {
                    count++;
                    temp.push(sum);
                }
            }
        }
    }
};

var isConfusingNumber = function(n) {
    const rotateDigits = { 0: 0, 1: 1, 6: 9, 8: 8, 9: 6 };
    const value = n;

    let num = 0;
    while(n > 0) {
        const d = n % 10;
        if (!rotateDigits.hasOwnProperty(d)) return false;

        num = num * 10 + rotateDigits[d];
        n = Math.floor(n / 10);
    }

    return num != value;
};

confusingNumberII(100);