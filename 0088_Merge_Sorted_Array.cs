// Problem statement: https://leetcode.com/problems/merge-sorted-array/

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int p1 = m-1, p2 = n-1;
        for (int p = n+m-1; p >= 0; p--) {
            if (p2 < 0 || p1 >= 0 && nums1[p1] > nums2[p2])
                nums1[p] = nums1[p1--];
            else
                nums1[p] = nums2[p2--];
        }
    }
}