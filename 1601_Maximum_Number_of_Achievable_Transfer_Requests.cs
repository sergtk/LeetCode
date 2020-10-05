public class Solution {
    public int MaximumRequests(int n, int[][] requests) {
        int nr = requests.Length;
        int[] dst = new int[n];
        int[] src = new int[n];
        
        int ret = 0;
        for (int reqMask = 1; reqMask < (1<<nr); reqMask++)
        {
            int[] delta = new int[n];
            int cur = 0;
            for (int r = 0; r < nr; r++) {
                if (((1<<r) & reqMask) > 0) {
                    delta[requests[r][0]]++;
                    delta[requests[r][1]]--;
                    cur++;
                }
            }
            bool ok = true;
            for (int b = 0; b < n; b++) {
                if (delta[b] != 0) {
                    ok = false;
                    break;
                }
            }
            if (ok && cur > ret) {
                ret = cur;
            }
        }
        return ret;
    }
}
