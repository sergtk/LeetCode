/**
Problem statement: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/

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
    int n;
    int[] nums;
    
    TreeNode tree(int min, int max) {
        int mid = (min+max)/2;
        var ret = new TreeNode(nums[mid]);
        if (min < mid) {
            var left = tree(min, mid-1);
            ret.left = left;
        }
        if (mid < max) {
            var right = tree(mid+1, max);
            ret.right = right;
        }
        return ret;
    }
    
    public TreeNode SortedArrayToBST(int[] nums) {
        this.nums = nums;
        n = nums.Length;
        TreeNode ret = tree(0, n-1);
        return ret;
    }
}