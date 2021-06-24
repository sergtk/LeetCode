// Problem statement: https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

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
    
    int[] preorder, inorder;
    
    // [)
    TreeNode Build(int pmin, int pmax, int imin, int imax) {
        if (pmin == pmax) return null;
        TreeNode ret = new TreeNode(preorder[pmin]);
        int i1 = Array.FindIndex(inorder, imin, v => v == preorder[pmin]);
        int leftSize = i1 - imin;
        TreeNode left = Build(pmin+1, pmin+leftSize+1, imin, i1);
        TreeNode right = Build(pmin+leftSize+1, pmax, i1+1, imax);
        ret.left = left;
        ret.right = right;
        return ret;
    }
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        this.preorder = preorder;
        this.inorder = inorder;
        int n = preorder.Length;
        
        TreeNode ret = Build(0, n, 0, n);
        return ret;
    }
}