/**
 * Given a non-negative index k where k ¡Ü 33, return the kth index row of the Pascal's triangle.
 * Note that the row index starts from 0.
 * In Pascal's triangle, each number is the sum of the two numbers directly above it.
 * 
 * Example:
 * Input: 3
 * Output: [1,3,3,1]
 * 
 * @param {number} rowIndex
 * @return {number[]}
 */
var getRow = function(rowIndex, row = null) {
  row = row || [];
  
  if (rowIndex < 0) {
    return row;
  }
  
  let preNum = 0, curNum = 0;
  getRow(rowIndex - 1, row);
  for (j = 0; j <= rowIndex; j++) {
    preNum = curNum;
    curNum = row[j];
    
    if (j === 0 || j === rowIndex) {
      row[j] = 1;
    } else {
      row[j] = preNum + curNum;
    }
  }
  
  return row;
};