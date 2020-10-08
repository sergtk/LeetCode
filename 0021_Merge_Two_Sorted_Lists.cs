/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    
    ListNode ret = null, tail = null;
    
    void AddNode(ListNode node) {
        if (ret == null) {
            ret = tail = node;
        } else {
            tail.next = node;
            tail = tail.next;
        }
    }
    
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        while (l1 != null && l2 != null) {
            ListNode next;
            if (l1.val < l2.val) {
                next = l1;
                l1 = l1.next;
            } else {
                next = l2;
                l2 = l2.next;
            }
            AddNode(next);
        }
        while (l1 != null) {
            ListNode next = l1;
            l1 = l1.next;
            AddNode(next);
        }
        while (l2 != null) {
            ListNode next = l2;
            l2 = l2.next;
            AddNode(next);
        }
        //Console.WriteLine($"ret.val = '{ret?.val}'");
        return ret;
    }
}
