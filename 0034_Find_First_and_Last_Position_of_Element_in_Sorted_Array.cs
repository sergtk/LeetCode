/*
Test cases:
[5,7,7,8,8,10]
8
[5,7,7,8,8,10]
6
[]
0
[8]
8
[8, 8, 8]
8
[8, 8, 8]
5
[8, 8, 8]
10
[8, 9, 10]
8
[8, 9, 10]
10
*/

using System.Diagnostics;

public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if (nums.Length == 0)
            return new int[]{-1, -1};
        int min1 = 0;
        int max1 = nums.Length - 1;
        while (min1 < max1)
        {
            int md = (min1 + max1) / 2;
            if (nums[md] < target)
                min1 = md + 1;
            else
                max1 = md;
        }
        if (nums[min1] != target)
            return new[]{-1, -1};
        int min2 = min1;
        int max2 = nums.Length;
        while (min2 < max2)
        {
            int md = (min2 + max2) / 2;
            if (nums[md] <= target)
                min2 = md + 1;
            else
                max2 = md;
        }
        //Debug.Assert(min2 == max2);
        return new int[] {min1, min2 - 1};
    }
}
