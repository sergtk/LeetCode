public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int n = nums.Length;
        int[] ss = new int[n];
        Array.Copy(nums, ss, n);
        Array.Sort(ss);
        int j = nums.Length - 1;
        int i;
        for (i = 0; i < n; i++) {
            while (ss[i] + ss[j] > target)
                j--;
            if (ss[i] + ss[j] == target)
                break;
        }
        //Console.WriteLine($"ss[{i}] == {ss[i]}, ss[{j}] == {ss[j]}");
        int[] ret = new int[] {-1, -1};
        for (int k = 0; k < nums.Length; k++)
        {
            if (nums[k] == ss[i] || nums[k] == ss[j])
            {
                if (ret[0] == -1)
                    ret[0] = k;
                else 
                {
                    ret[1] = k;
                    return ret;
                }
            }
        }
        return null;
    }
}