/**
 * @param {string} s1
 * @param {string} s2
 * @return {string}
 */
var minWindow = function(s1, s2) {
  if (!s1 || !s2 || s1.length < s2.length) return '';

  const size = 26;
  const charA = "a".charCodeAt(0);

  let next = [];
  for (let i = 0; i < s1.length; i++) {
    next.push(new Array(size));
    next[i].fill(-1);
  }

  for (let i = s1.length - 2; i >= 0; i--) {
    for (j = 0; j < size; j++) {
      next[i][j] = next[i + 1][j];
    }

    const ch = s1[i + 1].charCodeAt(0) - charA;
    next[i][ch] = i + 1;
  }

  let starts = [];
  for (let i = 0; i < s1.length; i++) {
    if (s1[i] === s2[0]) starts.push(i);
  }

  let startIndex = -1;
  let minLength = 0;
  for (const start of starts) {
    let end = start;
    for (let i = 1; i < s2.length; i++) {
      end = next[end][s2[i].charCodeAt(0) - charA];
      if (end < 0) break;
    }

    if (end < 0) continue;

    if (startIndex < 0 || end - start + 1 < minLength) {
      startIndex = start;
      minLength = end - start + 1;
    }
  }

  return startIndex < 0 ? '' : s1.substr(startIndex, minLength);
};

minWindow("abcdebdde", "bde");