// Problem statement: https://leetcode.com/problems/jump-game/

public class Solution {
    public bool CanJump(int[] nums) {
        int reach = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (i > reach) return false;
            reach = Math.Max(reach, i + nums[i]);
        }
        return true;
    }
}
