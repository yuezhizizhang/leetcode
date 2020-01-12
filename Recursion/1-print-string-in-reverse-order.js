/**
 * Print a string in reverse order.
 * @param {string} str
 * @return {string} str in the reverse order
 */
function printReverse( str ) {
  if (!str) {
    return str;
  }

  let chars = [...str];
  return chars.reverse().join('');
}

/**
 * Print a string in reverse order recusively.
 * @param {string} str
 * @return {string} str in the reverse order
 */
function printReverseRecusively( str ) {
  if (!str || str.length <= 1) {
    return str;
  }

  const chars = [...str];
  return printReverseRecusively(chars.splice(1).join('')) + chars[0];
}