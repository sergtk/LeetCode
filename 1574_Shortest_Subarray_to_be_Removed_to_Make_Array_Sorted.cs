public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length;
        int p = 0;
        while (p < n-1 && arr[p] <= arr[p+1]) p++;
        if (p == n-1) return 0;
        int q = n-1;
        while (q > 0 && arr[q-1] <= arr[q]) q--;
        
        int ret = n;
        for (int qq = n, pp = p; qq >= q; qq--) {
            while (pp >= 0 && qq < n && arr[pp] > arr[qq]) 
                pp--;
            int cur = qq-pp-1;
            ret = Math.Min(ret, cur);
        }
        return ret;        
    }
}
