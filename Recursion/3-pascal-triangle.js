/**
 * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
 * 
 * Example:
 * Input: 5
 * Output:
 * [
 *      [1],
 *     [1,1],
 *    [1,2,1],
 *   [1,3,3,1],
 *  [1,4,6,4,1]
 * ]
 * 
 * @param {number} numRows
 * @return {number[][]}
 */
var generate = function(numRows) {
  let rows = [];
  
  let lastRow;
  for (let i = 0; i < numRows; i++) {
    let curRow = [];
    for (let j = 0; j <= i; j++) {
      if (j === 0 || j === i) {
        curRow.push(1);
      } else {
        curRow.push(lastRow[j - 1] + lastRow[j]);
      }
    }
    lastRow = curRow;
    rows.push(curRow);
  }
  
  return rows;
};