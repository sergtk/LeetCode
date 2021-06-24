// Problem statement: https://leetcode.com/problems/binary-tree-level-order-traversal/

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
    
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var ret = new List<IList<int>>();
        if (root == null)
            return ret;
        var cur = new List<int>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(null);
        while (q.Count > 0)
        {
            var node = q.Dequeue();
            if (node == null) {
                ret.Add(cur);
                cur = new List<int>();
                if (q.Count > 0)
                    q.Enqueue(null);
            } else {
                //Console.WriteLine(node.val);
                cur.Add(node.val);
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }
        return ret;
    }
}