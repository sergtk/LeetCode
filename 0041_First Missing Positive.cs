/*
Problem statement: https://leetcode.com/problems/first-missing-positive/

Some tests:
[1,2,0]
[3,4,-1,1]
[7,8,9,11,12]
[-2147483648, 2147483647, 0, 1, 2, 3, 5]
[3,4,5,1,2,3]
[3,4,5,0,1,2,3]
[5,6,7,1,2,3,4]
[5,6,7,1,2,3,4,5]
[4,4,4,1,1,1,2,2,2,3,3,3]
[1,1,1,2,2,2,3,3,3]

*/




public class Solution {
    
    private const int Pres = int.MinValue;
        
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) 
            if (nums[i] < 0) 
                nums[i] = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0 || nums[i] == Pres)
                continue;
            int v = Math.Abs(nums[i]);
            if (v > n || nums[v-1] < 0)
                continue;
            if (nums[v-1] > 0)
                nums[v-1] = -nums[v-1];
            else
                nums[v-1] = Pres;
        }
        // System.Console.WriteLine(string.Join(", ", nums));
        for (int i = 0; i < n; i++) {
            if (nums[i] >= 0)
                return i+1;
        }
        return n+1;
    }
}
