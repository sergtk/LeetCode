public class Solution {
    
    int Calc(int[] nums1, int[] nums2)
    {
        Dictionary<long, int> dict = new Dictionary<long, int>();
        foreach (var v in nums1) {
            long v2 = (long)v * v;
            if (dict.ContainsKey(v2)) {
                dict[v2]++;
            } else {
                dict.Add(v2, 1);
            }
        }
        int ret = 0;
        for (int j = 0; j < nums2.Length; j++) {
            for (int k = j+1; k < nums2.Length; k++) {
                long mul = (long)nums2[j] * nums2[k];
                int val;
                if (dict.TryGetValue(mul, out val)) {
                    ret += val;
                }
            }
        }
        return ret;
    }
    
    public int NumTriplets(int[] nums1, int[] nums2) {
        int ret1 = Calc(nums1, nums2);
        int ret2 = Calc(nums2, nums1);
        int ret = ret1 + ret2;
        return ret;
    }
}
