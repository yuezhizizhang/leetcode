/**
 * // This is the master's API interface.
 * // You should not implement it, or speculate about its implementation
 * function Master() {
 *
 *     @param {string[]} wordlist
 *     @param {Master} master
 *     @return {integer}
 *     this.guess = function(word) {
 *         ...
 *     };
 * };
 */
/**
 * @param {string[]} wordlist
 * @param {Master} master
 * @return {void}
 */
var findSecretWord = function(wordlist, master) {
    const numOfGuesses = 10;
    const wordLength = 6;

    let scores = [];
    for (let i = 0; i < wordLength; i++) {
      let alphabet = new Array(26);
      scores.push(alphabet.fill(0));
    }

    const aCharCode = 'a'.charCodeAt(0);
    for (const word of wordlist) {
      for (let i = 0; i < wordLength; i++) {
        let ch = word[i].charCodeAt(0) - aCharCode;
        scores[i][ch]++;
      }
    }

    for (let i = 0; i < numOfGuesses; i++) {
      if (wordlist.length == 0) return;

      const word = chooseMostCommonWord(wordlist, scores);
      let match = master.guess(word);
      if (match === wordLength) return;

      wordlist = filterWords(wordlist, word, match);
    }
};

var chooseMostCommonWord = function(wordlist, scores) {
  let chosen = null;
  let score = 0;

  for (const word of wordlist) {
    let value = computeScore(word, scores);
    if (value > score) {
      score = value;
      chosen = word;
    }
  }

  return chosen;
};

var computeScore = function(word, scores) {
  const wordLength = 6;

  let sum = 0;
  const aCharCode = 'a'.charCodeAt(0);
  for (let i = 0; i < wordLength; i++) {
    const ch = word[i].charCodeAt(0) - aCharCode;
    sum += scores[i][ch];
  }

  return sum;
};

var filterWords = function(wordlist, word, match) {
  var filterList = [];

  for (const wd of wordlist) {
    if (wd === word) continue;
    
    if (isNMatch(word, wd, match)) filterList.push(wd);
  }

  return filterList;
};

var isNMatch = function(w1, w2, n) {
  const wordLength = 6;

  var match = 0;
  for (let i = 0; i < wordLength; i++) {
    if (w1[i] === w2[i]) match++;
  }

  return match === n;
};

findSecretWord(["acckzz","ccbazz","eiowzz","abcczz"], "acckzz");