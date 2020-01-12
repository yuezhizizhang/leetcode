/**
 * Maximum Depth of Binary Tree
 * https://leetcode.com/problems/maximum-depth-of-binary-tree/
 * 
 * Given a binary tree, find its maximum depth.
 * The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
 * Note: A leaf is a node with no children.
 * 
 * Example:
 * Given binary tree [3,9,20,null,null,15,7],
 * return its depth = 3.
 */
/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */
/**
 * Tail Recursion
 * 
 * @param {TreeNode} root
 * @return {number}
 */
var maxDepth = function(root, level = 0) {
  if (!root) {
    return level;
  }
  
  level++;
  return Math.max(maxDepth(root.left, level), maxDepth(root.right, level));
};


/**
 * Memoization with Stack
 * 
 * @param {TreeNode} root
 * @return {number}
 */
var maxDepth = function(root) {
  if (!root) {
    return 0;
  }
  
  let nodes = [root];
  let level = 0;
  while (nodes.length > 0) {
    level++;
    
    let children = [];
    for (let node of nodes) {
      if (!!node.left) {
        children.push(node.left);
      }
      if (!!node.right) {
        children.push(node.right);
      }
    }
    nodes = children;
  }
  
  return level;
}