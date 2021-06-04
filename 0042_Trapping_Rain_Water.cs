/*

Statement: https://leetcode.com/problems/trapping-rain-water/submissions/


Some input test data:
[0,1,0,2,1,0,1,3,2,1,2,1]
[4,2,0,3,2,5]
[1,1,1,1,1,1]
[1,1,1,1,1,5]
[5,1,1,1,1,5]
[5,1,1,1,1,1]
[]
[1]
[2,3]
[3,2]
[1, 3, 3]
*/

public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        if (n <= 2) return 0;
        int[] max1 = new int[n];
        int[] max2 = new int[n];
        
        max1[0] = height[0];
        for (int i = 1; i < n; i++) {
            max1[i] = Math.Max(max1[i-1], height[i]);
        }
        max2[n-1] = height[n-1];
        for (int i = n-2; i >= 0; i--) {
            max2[i] = Math.Max(max2[i+1], height[i]);
        }
        
        int ret = 0;
        for (int i = 1; i < n-1; i ++) {
            int m = Math.Min(max1[i-1], max2[i+1]);
            if (m > height[i]) {
                ret += m - height[i];
            }
        }
        return ret;
        
    }
}
