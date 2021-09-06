## 1110. Delete Nodes And Return Forest
https://leetcode.com/problems/delete-nodes-and-return-forest/

> Given the root of a binary tree, each node in the tree has a distinct value.
> After deleting all nodes with a value in to_delete, we are left with a forest (a disjoint union of trees).
> Return the roots of the trees in the remaining forest. You may return the result in any order.
>
> Example 1:
>   Input: root = [1,2,3,4,5,6,7], to_delete = [3,5]
>   Output: [[1,2,null,4],[6],[7]]
>
> Example 2:
>   Input: root = [1,2,4,null,3], to_delete = [3]
>   Output: [[1,2,4]]
>
> Constraints:
> * The number of nodes in the given tree is at most 1000.
> * Each node has a distinct value between 1 and 1000.
> * to_delete.length <= 1000
> * to_delete contains distinct values between 1 and 1000.

** Solution **

```C#
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
public class Solution {
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
}
```

```JavaScript
/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @param {number[]} to_delete
 * @return {TreeNode[]}
 */
var delNodes = function(root, to_delete) {
    var deleteSet = new Set(to_delete);
    var forest = [];
    buildForest(root, null, deleteSet, forest);
    return forest;
};

var buildForest = function(node, parent, deleteSet, forest) {
	if (!node) {
		return;
	}

	let toDelete = deleteSet.has(node.val);

	if (!toDelete && !parent) {
		forest.push(node);
	}

	if (toDelete && !!parent) {
		if (parent.left === node) {
			parent.left = null;
		} else {
			parent.right = null;
		}
	}

	parent = toDelete ? null : node;
	buildForest(node.left, parent, deleteSet, forest);
	buildForest(node.right, parent, deleteSet, forest);
};
```