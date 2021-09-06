/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function(s) {
    let longest = '';

    for (let i = 0; i < s.length; i++) {
    	let result = findLongestPalindrome(s, i, i, longest.length);
    	if (!!result) {
    		longest = result;
    	}
    	
    	result = findLongestPalindrome(s, i, i + 1, longest.length);
    	if (!!result) {
    		longest = result;
    	}
    }

    return longest;
};

var findLongestPalindrome = function(s, l, r, max) {
	let longest = '';

	while (l >= 0 && r < s.length)
	{
		if (s[l] !== s[r]) {
			break;
		}

		var length = r - l + 1;
		if (length > max) {
			longest = s.substr(l, length);
		}

		l--;
		r++;
	}

	return longest;
}

longestPalindrome('babad');