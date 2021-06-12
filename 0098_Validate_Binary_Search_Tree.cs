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
    
    bool res;
    
    (int, int) MinMax(TreeNode root) {
        if (!res) return (0, 0);
        var ret = (root.val, root.val);
        if (root.left != null)
        {
            var left = MinMax(root.left);
            if (left.Item2 >= root.val) {
                //Console.WriteLine($"left. {left.Item2} >= {root.val}");
                res = false;
            }
            ret.Item1 = left.Item1;
        }
        if (root.right != null)
        {
            var right = MinMax(root.right);
            if (right.Item1 <= root.val) {
                //Console.WriteLine($"right. {right.Item1} <= {root.val}");
                res = false;
            }
            ret.Item2 = right.Item2;
        }
        return ret;
    } 
    
    public bool IsValidBST(TreeNode root) {
        res = true;
        MinMax(root);
        return res;
    }
}