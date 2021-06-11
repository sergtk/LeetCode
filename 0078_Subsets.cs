// Problem statement: https://leetcode.com/problems/subsets/

public class Solution {
    
        
    public IList<IList<int>> Subsets(int[] nums) {
        int n = nums.Length;
        var ret = new List<IList<int>>();
        for (int mask = 0; mask < (1<<n); mask++) {
            var cur = new List<int>(n);
            for (int i = 0; i < n; i++) {
                if ((1<<i & mask) > 0) {
                    cur.Add(nums[i]);
                }
            }
            ret.Add(cur);
        }
        return ret;
    }
}
