// Problem statement: https://leetcode.com/problems/permutations/

public class Solution {
    
    int n;
    int[] nums;
    IList<IList<int>> res;
    
    void Step(int i)
    {
        if (i == n) {
            IList<int> perm = new List<int>(nums);
            res.Add(perm);
        }
        for (int j = i; j < n; j++) {
            (nums[i], nums[j]) = (nums[j], nums[i]);
            Step(i+1);
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
    }
    
    public IList<IList<int>> Permute(int[] nums) {
        this.nums = nums;
        n = nums.Length;
        res = new List<IList<int>>();
        Step(0);
        return this.res;        
    }
}
