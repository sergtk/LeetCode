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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode h = head;
        for (int i = 0; i < n; i++) h = h.next;
        ListNode t = head;
        ListNode t1 = null;
        while (h != null) {
            h = h.next;
            t1 = t;
            t = t.next;
        }
        
        if (t1 == null) {
            //Console.WriteLine($"t.val = {t.val}");
            head = t.next;
        } else {
            //Console.WriteLine($"t1.val = {t1.val}");
            t1.next = t.next;
        }
        return head;
    }
}
