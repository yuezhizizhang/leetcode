using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public string GetHint(string secret, string guess)
        {
            if (secret.Length != guess.Length)
            {
                throw new ArgumentException();
            }

            const int size = 10;
            var bulls = 0;
            var cows = 0;
            var scount = new int[size];
            var gcount = new int[size];
            var keys = new HashSet<int>();

            for (var i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    var index = secret[i] - '0';
                    scount[index]++;
                    keys.Add(index);
                    index = guess[i] - '0';
                    gcount[index]++;
                }
            }

            foreach (var key in keys)
            {
                cows += Math.Min(scount[key], gcount[key]);
            }

            return $"{bulls}A{cows}B";
        }
    }
}
