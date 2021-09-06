## 273. Integer to English Words
https://leetcode.com/problems/integer-to-english-words/

> Convert a non-negative integer num to its English words representation.
>
> Example 1:
>   Input: num = 123
>   Output: "One Hundred Twenty Three"
>
> Example 2:
>   Input: num = 12345
>   Output: "Twelve Thousand Three Hundred Forty Five"
>
> Example 3:
>   Input: num = 1234567
>   Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
>
> Example 4:
>   Input: num = 1234567891
>   Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
>
> Constraints:
> * 0 <= num <= 231 - 1

** Solution **

```C#
public class Solution 
{
    public readonly string[] WholeNumbersWords = new string[] 
    {
        "Thousand",
        "Million",
        "Billion"
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
        "Nine"
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
        "Nineteen"
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
        "Ninety"
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
```

```JavaScript
var numberToWords = function(num) {
    if (num === 0) {
        return 'Zero';
    }

	const wholeNumbersWords = ['Thousand', 'Million', 'Billion'];
    let numStr = '' + num;
    let divisions = Math.floor((numStr.length - 1) / 3);

    let start = 0;
    let leftDivision = numStr.length % 3;
    if (leftDivision === 0) {
    	leftDivision = 3;
    }

    let str = '';
    while (start < numStr.length) {
    	let subNum = numStr.substr(start, leftDivision);
        if (subNum > 0) {
        	str += buildHundredsWords(parseInt(subNum));
        	if (divisions > 0) {
        		str += `${wholeNumbersWords[divisions - 1]} `;
        	}
        }

    	divisions--;
    	start += leftDivision;
    	leftDivision = 3;
    }

    return str.trim();
};

var buildHundredsWords = function(num) {
	const oneDigitWords = ['One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'];
    const oneTensWords = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];
    const tensWords = ['Twenty', 'Thirty', 'Forty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety'];

    let hundreds = Math.floor(num / 100);
    num = num % 100;
    let tens = Math.floor(num / 10);
    let ones = num % 10;

    let str = '';
    if (hundreds > 0) {
    	str = `${oneDigitWords[hundreds - 1]} Hundred `;
    }

    if (tens == 1) {
    	str += `${oneTensWords[ones]} `;
    	return str;
    } else if (tens > 0) {
    	str += `${tensWords[tens - 2]} `;
    }

    if (ones > 0) {
    	str += `${oneDigitWords[ones - 1]} `;
    }

    return str;
}
```