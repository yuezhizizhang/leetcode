var expressiveWords = function(s, words) {
    if (!s || !words || words.length < 1) return 0;

    let counter = [];
    let str = group(s, counter);

    let total = 0;
    for (let word of words) {
        if (word.length < str.length || word.length > s.length) continue;

        if (word === str) {
            total++;
            continue;
        }

        if (isStretchy(word, counter)) total++;
    }

    return total;
};

var group = function(s, counter) {
    let str = '';

    let start = 0;
    for (let i = 1; i < s.length; i++) {
        if (s[i] === s[start]) continue;

        let cnt = i - start;
        if (cnt === 2) {
            str += s[start];
            counter.push({ key: s[start], value: 1 });
            str += s[start];
            counter.push({ key: s[start], value: 1 });
        } else {
            str += s[start];
            counter.push({ key: s[start], value: cnt });
        }

        start = i;
    }

    if (start < s.length) {
        let cnt = s.length - start;
        if (cnt === 2) {
            str += s[start];
            counter.push({ key: s[start], value: 1 });
            str += s[start];
            counter.push({ key: s[start], value: 1 });
        } else {
            str += s[start];
            counter.push({ key: s[start], value: cnt });
        }
    }

    return str;
};

var isStretchy = function(word, counter) {
    let j = 0;
    let i = 0;
    while (i < word.length && j < counter.length) {
        if (word[i] !== counter[j].key) return false;

        let occurs = counter[j].value;
        if (occurs > 1) {
            let start = i;
            while(++i < word.length && word[i] === word[start]) {}

            let cnt = i - start;
            if (cnt > occurs) return false;

            j++;
        } else {
            i++;
            j++;
        }
    }

    return i >= word.length;
};

expressiveWords("zzzzzyyyyy", ["zzyy","zy","zyy"]);