/*
Problem statement: https://leetcode.com/problems/binary-tree-maximum-path-sum/

Some test cases:
[-3]
[-100,10,10]
[-5,10,10]
[1,2,3]
[-10,9,20,null,null,15,7]

*/

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
    
    int best;
    
    int MaxEnding(TreeNode root) {
        if (root == null) return 0;
        int leftBest = MaxEnding(root.left);
        int rightBest = MaxEnding(root.right);
        
        int cur = Math.Max(Math.Max(leftBest, rightBest), Math.Max(leftBest + rightBest, 0));
        cur += root.val;
        best = Math.Max(best, cur);
        
        int ret = Math.Max(Math.Max(leftBest, rightBest), 0);
        ret += root.val;
        return ret;
        
    }
    
    public int MaxPathSum(TreeNode root) {
        best = root.val;
        MaxEnding(root);
        return best;
    }
}