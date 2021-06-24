// Problem statement: https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/

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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var ret = new List<IList<int>>();
        if (root == null)
            return ret;
        var cur = new List<int>();
        var lev = new List<TreeNode>();
        var lev_next = new List<TreeNode>();
        bool rev = false;
        lev.Add(root);
        while (lev.Count > 0)
        {
            foreach (var node in lev) {
                if (node.left != null) lev_next.Add(node.left);
                if (node.right != null) lev_next.Add(node.right);
            }
            if (rev) lev.Reverse();
            rev = !rev;
            ret.Add(lev.Select(nd => nd.val).ToList());
            (lev, lev_next) = (lev_next, lev);
            lev_next.Clear();
        }
        return ret;        
    }
}