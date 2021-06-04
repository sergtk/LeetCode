/*
Problem statement: https://leetcode.com/problems/maximum-subarray/

Some test cases:
[-1,-1,-1]
[-1,5,-1]
[0]
[-10,-5]
[-5,-10]
[-2,1,-3,4,-1,2,1,-5,4]
[1]
[5,4,-1,7,8]

*/

public class Solution {
    public int MaxSubArray(int[] nums) {
        int n = nums.Length;
        
        if (nums.All(v => v < 0)) {
            int ret1 = nums.Max();
            return ret1;
        }
        
        int sum = 0;
        int min = 0;

        int ret = 0;
        for (int i = 0; i < n; i++) {
            sum += nums[i];
            min = Math.Min(min, sum);
            int cur = sum - min;
            ret = Math.Max(ret, cur);
        }
        return ret;
    }
}
