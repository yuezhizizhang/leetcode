## 68. Text Justification
https://leetcode.com/problems/text-justification/

> Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.
> You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.
> Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
> For the last line of text, it should be left-justified and no extra space is inserted between words.
>
> Note:
> * A word is defined as a character sequence consisting of non-space characters only.
> * Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
> * The input array words contains at least one word.
>
> Example 1:
> Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
> Output:
> [
>   "This    is    an",
>   "example  of text",
>   "justification.  "
> ]
>
> Example 2:
> Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
> Output:
> [
>   "What   must   be",
>   "acknowledgment  ",
>   "shall be        "
> ]
> Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must be left-justified instead of fully-justified.
> Note that the second line is also left-justified becase it contains only one word.
>
> Example 3:
> Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
> Output:
> [
>   "Science  is  what we",
>   "understand      well",
>   "enough to explain to",
>   "a  computer.  Art is",
>   "everything  else  we",
>  "do                  "
> ]
>
> Constraints:
> * 1 <= words.length <= 300
> * 1 <= words[i].length <= 20
> * words[i] consists of only English letters and symbols.
> * 1 <= maxWidth <= 100
> * words[i].length <= maxWidth

**Solution:**

Time Complexity: O(n), Space Complexity: O(n)

```C#
public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        if (words.Length <= 0)
        {
            return null;
        }

        var lines = new List<string>();
        var lineLength = words[0].Length;
        var wordsLength = words[0].Length;
        var start = 0;

        for (var i = 1; i < words.Length; i++)
        {
            if (lineLength + words[i].Length + 1 <= maxWidth)
            {
                lineLength += words[i].Length + 1;
                wordsLength += words[i].Length;
            }
            else
            {
                var line = BuildLine(words, start, i - 1, wordsLength, maxWidth);
                lines.Add(line);

                start = i;
                wordsLength = lineLength = words[i].Length;
            }
        }

        if (start < words.Length)
        {
            var line = BuildLastLine(words, start, wordsLength, maxWidth);
            lines.Add(line);
        }

        return lines;
    }

    private string BuildLine(string[] words, int start, int end, int length, int maxWidth)
    {
        var numOfPads = end - start;
        var spaces = maxWidth - length;

        if (numOfPads == 0)
        {
            return words[start].PadRight(maxWidth);
        }

        var spacesPerPad = (int)(spaces / numOfPads);
        var remainingSpaces = spaces % numOfPads;

        var sb = new StringBuilder();
        for (var i = start; i <= end; i++)
        {
            sb.Append(words[i]);
            if (i < end)
            {
                var spacePads = spacesPerPad;
                if (remainingSpaces > 0)
                {
                    spacePads += 1;
                    remainingSpaces--;
                }
                sb.Append(new String(' ', spacePads));
            }
        }

        return sb.ToString();
    }

    private string BuildLastLine(string[] words, int start, int length, int maxWidth)
    {
        // LINQ is very slow, even though the codes look much neater.
        // return string.Join(' ', words.Skip(start)).PadRight(maxWidth);

        var sb = new StringBuilder();
        sb.Append(words[start]);
        for (var i = start + 1; i < words.Length; i++)
        {
            sb.Append(' ');
            sb.Append(words[i]);
        }

        return sb.ToString().PadRight(maxWidth);
    }
}
```

```JavaScript
/**
 * @param {string[]} words
 * @param {number} maxWidth
 * @return {string[]}
 */
var fullJustify = function(words, maxWidth) {
    if (words.length <= 0) {
    	return null;
    }

    let lines = [];
    let wordsLength = words[0].length;
    let lineLength = words[0].length;
    let start = 0;
    for (let i = 1; i < words.length; i++) {
    	if (lineLength + words[i].length + 1 <= maxWidth) {
    		wordsLength += words[i].length;
    		lineLength += words[i].length + 1;
    	} else {
    		lines.push(buildLine(words, start, i - 1, wordsLength, maxWidth));

    		start = i;
    		wordsLength = lineLength = words[i].length;
    	}
    }

    if (start < words.length) {
    	lines.push(buildLastLine(words, start, maxWidth));
    }

    return lines;
};

var buildLine = function(words, start, end, wordsLength, maxWidth) {
	let numOfPads = end - start;
	let numOfSpaces = maxWidth - wordsLength;

	if (numOfPads === 0) {
		return words[start].padEnd(maxWidth);
	}

	let spacesPerPad = Math.floor(numOfSpaces / numOfPads);
	let remainingSpaces = numOfSpaces % numOfPads;
	let sb = [words[start]];
	for (let i = start + 1; i <= end; i++) {
		let spaces = spacesPerPad;
		if (remainingSpaces > 0) {
			spaces += 1;
			remainingSpaces--;
		}
		sb.push(new Array(spaces).fill(' ').join(''));
		sb.push(words[i]);
	}

	return sb.join('');
}

var buildLastLine = function(words, start, maxWidth) {
	return words.slice(start).join(' ').padEnd(maxWidth);
}
```