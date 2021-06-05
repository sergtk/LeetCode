// Problem statement: https://leetcode.com/problems/plus-one/

public class Solution {
    public int[] PlusOne(int[] digits) {
        int n = digits.Length;
        int mem = 1;
        for (int i = n - 1; i >= 0; i--) {
            int tot = digits[i] + mem;
            if (tot == 10) {
                digits[i] = 0;
                mem = 1;
            } else {
                digits[i] = tot;
                mem = 0;
            }
        }
        if (mem == 1) {
            var ret = new int[n+1];
            Array.Copy(digits, 0, ret, 1, n);
            ret[0] = 1;
            return ret;
        } else {
            return digits;
        }
    }
}
