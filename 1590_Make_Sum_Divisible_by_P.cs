public class Solution {
    public int MinSubarray(int[] nums, int p) {
        int n = nums.Length;
        long totalSum = nums.Sum(v => (long)v);
        
        int needRem = (int)(totalSum % p);
        //Console.WriteLine($"needRem = {needRem}");
        if (needRem == 0)
            return 0;
        
        Dictionary<int, int> remPoses = new Dictionary<int, int>();
        remPoses.Add(0, -1);
        
        int ret = 12345678;
        int curRem = 0;
        for (int i = 0; i < n; i++) {
            curRem = (curRem + nums[i]) % p;
            int findRem = (curRem - needRem + p) % p;
            
            /*
            Console.WriteLine($"{i}. {nums[i]} -> ({curRem}, {findRem})");
            if (i >= 7) {
                Console.WriteLine("   " + ((nums[i] - nums[i-7] + p) % p).ToString());
            }
            */
            
            if (remPoses.ContainsKey(findRem)) {
                int cur = i - remPoses[findRem];
                //Console.WriteLine($"Candidates: {remPoses[findRem] + 1} - {i} ({nums[i]})");
                if (cur < ret) {
                    ret = cur;
                }
            }
                
            remPoses[curRem] = i;
        }
        
        if (ret == n)
            ret = -1;
        return ret;
    }
}