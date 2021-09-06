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
            var num = 101;
            var solutions = new Solution();
            solutions.NumberToWords(num);
        }
    }

    public class Solution
    {
        public readonly string[] WholeNumbersWords = new string[] 
        {
            "Thousand",
            "Million",
            "Billion",
        };

        public readonly string[] OnesWords = new string[] 
        {
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
        };

        public readonly string[] OneTensWords = new string[]
        {
            "Ten",
            "Eleven",
            "Twelve",
            "Thirteen",
            "Fourteen",
            "Fifteen",
            "Sixteen",
            "Seventeen",
            "Eighteen",
            "Nineteen",
        };

        public readonly string[] TensWords = new string[]
        {
            "Twenty",
            "Thirty",
            "Forty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety",
        };

        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            var numString = num.ToString();
            var divisions = (numString.Length - 1) / 3;
            var leftDivision = numString.Length % 3;
            if (leftDivision == 0)
            {
                leftDivision = 3;
            }

            var sb = new StringBuilder();
            var start = 0;
            while (start < numString.Length)
            {
                var subNum = int.Parse(numString.Substring(start, leftDivision));
                if (subNum > 0)
                {
                    BuildHundredsWords(subNum, ref sb);
                    if (divisions > 0)
                    {
                        sb.Append($"{WholeNumbersWords[divisions - 1]} ");
                    }
                }

                start += leftDivision;
                leftDivision = 3;
                divisions--;
            }

            return sb.ToString().Trim();
        }

        private void BuildHundredsWords(int num, ref StringBuilder sb)
        {
            var hundreds = num / 100;
            num = num % 100;
            var tens = num / 10;
            var ones = num % 10;

            if (hundreds > 0)
            {
                sb.Append($"{OnesWords[hundreds - 1]} Hundred ");
            }

            if (tens == 1)
            {
                sb.Append($"{OneTensWords[ones]} ");
                return;
            }
            else if (tens > 1)
            {
                sb.Append($"{TensWords[tens - 2]} ");
            }

            if (ones > 0)
            {
                sb.Append($"{OnesWords[ones - 1]} ");
            }    
        }
    }
}
