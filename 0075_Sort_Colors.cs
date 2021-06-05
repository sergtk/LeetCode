/*
Problem statement: https://leetcode.com/problems/sort-colors/

Some test cases:
[1,2,0]
[1,0,2]
[2,0,1]
[2,0,2,1,1,0]
[2,0,1]
[0]
[1]
[2]
[0,0,0,0,0,1]
[0,0,0,0,0,2]
[2,0,0,0,0,0]
[1,0,0,0,0,0]
[1,1,1,1,1,1]
[2,2,2,2,2]
*/

public class Solution {
    public void SortColors(int[] nums) {
        int p0 = 0;
        int p2 = nums.Length-1;
        for (int i = 0; i <= p2; i++) {
            if (nums[i] == 0) {
                if (i > p0) {
                    (nums[p0], nums[i]) = (nums[i], nums[p0]);
                    i--;
                }
                p0++;
            } else if (nums[i] == 2) {
                (nums[p2], nums[i]) = (nums[i], nums[p2]);
                p2--;
                i--;
            }
        }
    }
}
