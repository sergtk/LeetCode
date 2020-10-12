public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        int k = 0;
        for (int i = 1; i < n; i++) {
            if (nums[i] != nums[k]) {
                nums[++k] = nums[i];
            }
        }
        return k+1;
    }
}
