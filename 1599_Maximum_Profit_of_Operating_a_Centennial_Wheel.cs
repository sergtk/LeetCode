public class Solution {
    public int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost) {
        int profit = 0;
        int ret = -1;
        int cur = 0;
        int wait = 0;
        for (int c = 0; c < customers.Length || wait > 0; c++)
        {
            if (c < customers.Length)
            {
                wait += customers[c];
            }
            int g = Math.Min(4, wait);
            wait -= g;
            cur += boardingCost * g - runningCost;
            
            if (cur > profit)
            {
                profit = cur;
                ret = c + 1;
                //Console.WriteLine($"profit = {profit}, rot = {ret}");
            }
        }
        return ret;
    }
}
