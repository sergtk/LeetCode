/*
Problem statement: https://leetcode.com/problems/first-missing-positive/

Some tests:
[3,4,-1,1]
[1,2,0]
[7,8,9,11,12]
[-2147483648, 2147483647, 0, 1, 2, 3, 5]
[3,4,5,1,2,3]
[3,4,5,0,1,2,3]
[5,6,7,1,2,3,4]
[5,6,7,1,2,3,4,5]
[4,4,4,1,1,1,2,2,2,3,3,3]
[1,1,1,2,2,2,3,3,3]
[1,2,3,4,5]
[5,4,3,2,1]
[39,8,43,12,38,11,-9,12,34,20,44,32,10,22,38,9,45,26,-4,2,1,3,3,20,38,17,20,25,41,35,37,18,37,34,24,29,39,9,36,28,23,18,-2,28,34,30]
*/


// Solution 1.

public class Solution {
    
    private const int Pres = int.MinValue;
        
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) 
            if (nums[i] < 0) 
                nums[i] = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0 || nums[i] == Pres)
                continue;
            int v = Math.Abs(nums[i]);
            if (v > n || nums[v-1] < 0)
                continue;
            if (nums[v-1] > 0)
                nums[v-1] = -nums[v-1];
            else
                nums[v-1] = Pres;
        }
        // System.Console.WriteLine(string.Join(", ", nums));
        for (int i = 0; i < n; i++) {
            if (nums[i] >= 0)
                return i+1;
        }
        return n+1;
    }
}

// Solution 2

public class Solution {
    
    private static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
    
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            int j = i;
            int v = nums[j];
            while (v > 0 && v <= n && j != v-1 && nums[v-1] != v) {
                Swap(ref nums[j], ref nums[v-1]);
                //j = v-1;
                v = nums[j];
            }
            //System.Console.WriteLine($"i={i}, v={v}");
            //System.Console.WriteLine(string.Join(", ", nums));
        }
        //System.Console.WriteLine(string.Join(", ", nums));
        for (int i = 0; i < n; i++) {
            if (nums[i] != i+1)
                return i+1;
        }
        return n+1;
    }
}
