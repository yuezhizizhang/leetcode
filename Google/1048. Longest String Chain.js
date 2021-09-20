/**
 * @param {string[]} words
 * @return {number}
 */
var longestStrChain = function(words) {
    words.sort((a, b) => a.length - b.length);

    let count = new Array(words.length).fill(0);
    let max = 0;
    for (let i = 0; i < words.length; i++) {
      max = Math.max(max, longest(words, count, i));
    }

    return max;
};

var longest = function(words, count, start) {
  if (count[start] > 0) return count[start];

  let predecessor = words[start];
  let max = 1;
  for (let i = start + 1; i < words.length; i++) {
    if (isPrecedessor(predecessor, words[i])) {
      max = Math.max(max, 1 + longest(words, count, i));
    }
  }

  count[start] = max;
  return max;
};

var isPrecedessor = function(predecessor, word) {
  if (predecessor.length + 1 !== word.length) return false;

  let i = 0, j = 0;
  let oneMismatch = false;
  while (i < predecessor.length && j < word.length) {
    if (predecessor[i] !== word[j]) {
      if (oneMismatch) return false;
      else {
        oneMismatch = true;
        j++;
      }
    } else {
      i++;
      j++;
    }
  }

  return i === predecessor.length;
};

longestStrChain(["a","b","ba","bca","bda","bdca"]);