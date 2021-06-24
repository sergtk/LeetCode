/*
Problem statement: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

Some test cases:
[10]
[10, 10]
[10, 10, 10]
[0]
[0, 0]
[0, 0, 0]
[7,1,5,3,6,4]
[7,6,4,3,1]
[1,2,3,4,5]

*/

public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        int ret = 0;
        for (int i = 0; i < n-1; i++) {
            int cur = prices[i+1] - prices[i];
            if (cur > 0)
                ret += cur;
        }
        return ret;
    }
}