var numSmallerByFrequency = function(queries, words) {
  const maxLength = 10;

  let freqs = new Array(maxLength + 1).fill(0);
  for (const word of words) {
    ++freqs[calcFrequency(word)];
  }

  for (let i = maxLength - 1; i > 0; i--) {
    freqs[i] += freqs[i + 1];
  }

  let result = [];
  for (const query of queries) {
    let count = calcFrequency(query);

    if (count >= maxLength) {
      result.push(0);
    } else {
      result.push(freqs[count + 1]);
    }
  }

  return result;
};

var calcFrequency = function(word) {
  if (!word) return 0;

  let ch = word[0];
  let count = 1;
  for (var i = 1; i < word.length; i++) {
    if (word[i] < ch) {
      ch = word[i];
      count = 1;
    } else if (word[i] === ch) {
      count++;
    }
  }

  return count;
};

numSmallerByFrequency(["cbd"], ["zaaaz"]);