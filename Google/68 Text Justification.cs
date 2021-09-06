using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            var solution = new Solution();
            solution.FullJustify(words, 16);
        }
    }

    public class Solution
    {
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


}
