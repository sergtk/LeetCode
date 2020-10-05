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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode head = null;
        ListNode tail = null;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0)
        {
            if (l1 != null)
            {
                carry += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                carry += l2.val;
                l2 = l2.next;
            }
            
            if (tail == null)
            {
                head = tail = new ListNode();
            } else
            {
                tail.next = new ListNode();
                tail = tail.next;
            }
            tail.val = carry % 10;
            carry /= 10;
        }
        return head;
    }
}
