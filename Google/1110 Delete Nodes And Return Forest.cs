using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            if (root == null || to_delete == null || to_delete.Length < 1)
            {
                return new List<TreeNode> { root };
            }

            var deleteSet = new HashSet<int>(to_delete);

            var forest = new List<TreeNode>();
            BuildForest(root, null, deleteSet, forest);

            return forest;
        }

        private void BuildForest(TreeNode node, TreeNode parent, ISet<int> delete, IList<TreeNode> forest)
        {
            if (node == null)
                return;

            var toDelete = delete.Contains(node.val);

            if (!toDelete && parent == null)
                forest.Add(node);

            if (toDelete && parent != null)
            {
                if (parent.left == node)
                    parent.left = null;
                else
                    parent.right = null;
            }

            parent = toDelete ? null : node;
            BuildForest(node.left, parent, delete, forest);
            BuildForest(node.right, parent, delete, forest);
        }

        public IList<TreeNode> DelNodesSlow(TreeNode root, int[] to_delete)
        {
            if (root == null || to_delete == null || to_delete.Length < 1)
            {
                return new List<TreeNode> { root };
            }

            var deleteSet = new HashSet<int>(to_delete);

            var forests = new List<TreeNode>();
            if (!deleteSet.Contains(root.val)) forests.Add(root);
            
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                var node = stack.Pop();
                
                if (node.left != null)
                {
                    stack.Push(node.left);
                    if (deleteSet.Contains(node.left.val)) node.left = null;
                }

                if (node.right != null)
                {
                    stack.Push(node.right);
                    if (deleteSet.Contains(node.right.val)) node.right = null;
                }

                if (deleteSet.Contains(node.val))
                {
                    if (node.left != null) forests.Add(node.left);
                    if (node.right != null) forests.Add(node.right);
                }
            }

            return forests;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
