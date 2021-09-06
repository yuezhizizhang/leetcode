/**
 * @param {string} s
 * @return {string}
 */
var minRemoveToMakeValid = function(s) {
    const leftBracket = '(';
    const rightBracket = ')';

    let stack = [];
    let result = [...s];
    for (let i = 0; i < s.length; i++) {
        if (s[i] === leftBracket) {
            stack.push(i);
        } else if (s[i] === rightBracket) {
            if (stack.length > 0) {
                stack.pop();
            } else {
                result[i] = '';
            }
        }
    }

    for (let i of stack) {
        result[i] = '';
    }

    return result.join('');
};

minRemoveToMakeValid("lee(t(c)o)de)");