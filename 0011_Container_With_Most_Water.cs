public class Solution {
    public int MaxArea(int[] height) {
        int n = height.Length;

        int[] maxToEnd = new int[n];
        int mxi = n-1;
        maxToEnd[n-1] = n-1;
        for (int i = n-2; i >= 0; i--)
        {
            if (height[i] > height[mxi]) {
                mxi = i;
            }
            maxToEnd[i] = mxi;
        }
        
        int[] maxToBegin = new int[n];
        mxi = 0;
        maxToBegin[0] = 0;
        for (int i = 1; i < n-1; i++)
        {
            if (height[i] > height[mxi]) {
                mxi = i;
            }
            maxToBegin[i] = mxi;
        }
        
        int p = maxToEnd[0];
        int q = p;
        int ret = 0;
        while (p > 0 || q < n-1) {
            int pMax = -1;
            if (p > 0)
                pMax = maxToBegin[p-1];
            int qMax = -1;
            if (q < n-1) {
                qMax = maxToEnd[q+1];
            }
            if (qMax == -1 || pMax != -1 && height[pMax] > height[qMax]) {
                p = pMax;
            } else {
                q = qMax;
            }
            int h = Math.Min(height[p], height[q]);
            int cur = (q - p) * h;
            //Console.WriteLine($"p={p}, q={q}, h={h} -> {cur}");
            if (cur > ret) {
                ret = cur;
            }
        }
        return ret;
    }
}
