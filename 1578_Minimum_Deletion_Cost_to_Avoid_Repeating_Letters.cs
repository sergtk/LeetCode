public class Solution {
    public int MinCost(string s, int[] cost) {
        int n = cost.Length;
        
        int ret = 0;
        for (int start = 0; start < n; ) {
            int end = start;
            int maxCost = -1;
            int sum = 0;
            while (end < n && s[end] == s[start]) {
                maxCost = Math.Max(maxCost, cost[end]);
                sum += cost[end];
                end++;
            }
            
            int cur = sum - maxCost;
            //Console.WriteLine($"start={start}, end={end}, char={s[start]}, sum={sum}, maxCost={maxCost}");
            ret += cur;
            start = end;
        }
        return ret;
    }
}
