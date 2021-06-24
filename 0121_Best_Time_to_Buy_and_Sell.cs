public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        var mn = new int[n];
        mn[0] = prices[0];
        int ret = 0;
        for (int i = 1; i < n; i++) {
            mn[i] = Math.Min(mn[i-1], prices[i]);
            int cur = prices[i] - mn[i];
            ret = Math.Max(ret, cur);
        }
        return ret;
    }
}