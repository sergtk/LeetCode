/*
Problem statement: https://leetcode.com/problems/largest-rectangle-in-histogram/

Some test cases:
[2,1,5,6,2,3]
[2,4]
[1,2,3,4,5,6,7,8,9,10]
[10,9,8,7,6,5,4,3,2,1]
[0,1,2,3,4,5,4,3,2,1]
[5,4,3,2,1,0,5,10,20,30]

*/

public class Solution {
    public int LargestRectangleArea(int[] hi) {
        int n = hi.Length;
        var low1 = new int[n];
        low1[0] = -1;
        for (int i = 1; i < n; i++) {
            //Console.WriteLine($"*** 1. {i}");
            int j = i-1;
            while (j > -1 && hi[i] <= hi[j]) {
                j = low1[j];
            }
            low1[i] = j;
        }

        var low2 = new int[n];
        low2[n-1] = n;
        for (int i = n-2; i >= 0; i--) {
            //Console.WriteLine($"*** 2. {i}");
            int j = i+1;
            while (j < n && hi[i] <= hi[j]) {
                j = low2[j];
            }
            low2[i] = j;
        }
        int ret = -1;
        for (int i = 0; i < n; i++) {
            int cur = hi[i] * (low2[i] - low1[i] - 1);
            ret = Math.Max(ret, cur);
        }
        return ret;
    }
}
