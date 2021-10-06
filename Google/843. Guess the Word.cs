using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /**
     * // This is the Master's API interface.
     * // You should not implement it, or speculate about its implementation
     * class Master {
     *     public int Guess(string word);
     * }
     */
    class Solution
    {
        private const int NumGuesses = 10;
        private const int WordLength = 6;

        public void FindSecretWord(string[] wordlist, Master master)
        {
            if (wordlist == null || wordlist.Length == 0) return;

            var scores = new int[WordLength][];
            for (var i = 0; i < WordLength; i++)
            {
                scores[i] = new int[26];
                Array.Fill(scores[i], 0);
            }

            foreach (var word in wordlist)
            {
                for (var i = 0; i < WordLength; i++)
                {
                    var ch = word[i] - 'a';
                    scores[i][ch]++;
                }
            }

            var filterList = new List<string>(wordlist);
            var guessedWords = new HashSet<string>();
            var rand = new Random();
            for (var i = 0; i < NumGuesses; i++)
            {
                if (filterList.Count == 0) return;

                var word = FindMostCommonWord(filterList, scores);
                var match = master.guess(word);
                if (match == 6) return;

                filterList = FilterWords(word, filterList, match);
            }
        }

        private string FindMostCommonWord(IList<string> wordlist, int[][] scores)
        {
            var score = 0;
            var word = "";
            foreach(var wd in wordlist)
            {
                var value = ComputeScore(wd, scores);
                if (value > score)
                {
                    score = value;
                    word = wd;
                }
            }

            return word;
        }

        private int ComputeScore(string word, int[][] scores)
        {
            var sum = 0;
            for (var i = 0; i < WordLength; i++)
            {
                var index = word[i] - 'a';
                sum += scores[i][index];
            }

            return sum;
        }

        private List<string> FilterWords(string word, IList<string> wordlist, int match)
        {
            var filterList = new List<string>();

            foreach (var wd in wordlist)
            {
                if (CheckWord(word, wd, match)) filterList.Add(wd);
            }

            return filterList;
        }

        private bool CheckWord(string w1, string w2, int match)
        {
            var count = 0;
            for (var i = 0; i < WordLength; i++)
            {
                if (w1[i] == w2[i]) count++;
            }

            return count == match;
        }
    }
}
