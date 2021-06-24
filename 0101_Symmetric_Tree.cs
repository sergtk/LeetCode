// Problem statement: https://leetcode.com/problems/symmetric-tree/

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
    
    bool Sym(TreeNode left, TreeNode right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;
        if (left.val != right.val) return false;
        if (!Sym(left.left, right.right)) return false;
        if (!Sym(left.right, right.left)) return false;
        return true;
    }
    
    public bool IsSymmetric(TreeNode root)
    {
        var ret = Sym(root, root);
        return ret;
    }
}