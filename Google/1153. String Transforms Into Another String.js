/**
 * @param {string} str1
 * @param {string} str2
 * @return {boolean}
 */
var canConvert = function(str1, str2) {
    if (!str1 || !str2 || str1.length != str2.length) return false;

    let map = new Map();
    let changed = 0;
    let charsSet = new Set();
    let swap = false;
    for (let i = 0; i < str1.length; i++) {
        const convertFrom = str1[i];
        const convertTo = str2[i];

        if (!map.has(convertFrom)) {
            map.set(convertFrom, convertTo);

            if (!charsSet.has(convertTo)) charsSet.add(convertTo);

            if (convertFrom !== convertTo) {
                changed++;

                if (!swap && map.has(convertTo) && map.get(convertTo) === convertFrom)
                    swap = true;
            }
        } else if (map.get(convertFrom) !== convertTo) {
            return false;
        }
    }

    return charsSet.size < 26 || (!swap && changed < 26);
};

canConvert("abcdefghijklmnopqrstuvwxyz", "abcdefghijklmnopqrstuvwxzy");