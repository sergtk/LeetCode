/*
Problem statement: https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) return null;
        var level = new List<Node> {root};
        var prev_level = new List<Node>();
        while (level.Count > 0) {
            (level, prev_level) = (prev_level, level);
            if (prev_level[0].left == null) {
                break;
            }
            level.Clear();
            foreach (var node in prev_level) {
                level.Add(node.left);
                level.Add(node.right);
            }
            for (int i = 0; i < level.Count - 1; i++) {
                level[i].next = level[i+1];
            }
        }
        return root;
    }
}