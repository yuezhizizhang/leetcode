/**
 * @param {number} num
 * @return {string}
 */
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

numberToWords(12345);