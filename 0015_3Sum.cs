public class Solution {

    int CompareTriplets(int a0, int a1, int a2, IList<int> b) {
        if (a0 != b[0]) return a0-b[0];
        if (a1 != b[1]) return a1-b[1];
        return a2-b[2];
    }
    
    public IList<IList<int>> ThreeSum(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        List<IList<int>> ret = new List<IList<int>>();
        for (int i = 0; i < n; i++) {
            if (i > 0 && nums[i] == nums[i-1])
                // optimization
                continue;
            int k = n-1;
            for (int j = i+1; j < n; j++) {
                while (k > j && nums[i] + nums[j] + nums[k] > 0)
                    k--;
                if (k == j) break;
                
                if (nums[i] + nums[j] + nums[k] == 0) {
                    if (ret.Count == 0 || CompareTriplets(nums[i], nums[j], nums[k], ret[ret.Count - 1]) > 0)
                    {
                        List<int> tr = new List<int>(3);
                        tr.Add(nums[i]);
                        tr.Add(nums[j]);
                        tr.Add(nums[k]);
                        ret.Add(tr);
                    }
                }
            }
        }
        return ret;
    }
}
