public class Solution {
    public int MaxSumRangeQuery(int[] nums, int[][] requests) {
        int n = nums.Length;
        int nr = requests.Length;
        int np = nr * 2;
        (int, byte)[] points = new (int, byte)[np];
        
        for (int r = 0; r < nr; r++) {
            points[r * 2] = (requests[r][0], 0);
            points[r * 2 + 1] = (requests[r][1], 1);
        }
        Array.Sort(points);
        
        int p = 0;
        
        int[] count = new int[n];
        int cur = 0;
        for (int i = 0; i < n; i++) {
            while (p < np && points[p].Item1 == i && points[p].Item2 == 0) {
                p++;
                cur++;
            }
            count[i] = cur;
            while (p < np && points[p].Item1 == i && points[p].Item2 == 1) {
                p++;
                cur--;
            }
        }
        
        Array.Sort(count);
        Array.Sort(nums);

        long ret = 0;
        for (int i = 0; i < n; i++) {
            ret += (long)count[i] * nums[i];
        }
        ret = ret % (1000000000+7);
        return (int)ret;        
    }
}