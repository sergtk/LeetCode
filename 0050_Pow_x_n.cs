/*
Problem statement: https://leetcode.com/problems/powx-n/

Some test cases:
0
0
0
1
1
0
1
-2147483648
1
2147483647
-1
-2147483648
-1
2147483647
0
2147483647
2.00000
10
2.10000
3
2.00000
-2

*/

public class Solution {
    public double MyPow(double x, int n) {
        if (n == int.MinValue) {
            double ret = 1 / MyPow(x, int.MaxValue) / x;
            return ret;
        }
        if (n < 0) {
            double ret = 1 / MyPow(x, -n);
            return ret;
        }
        
        double res = 1;
        while (n > 0) {
            if ((n & 1) == 1) {
                res *= x;
            }
            n /= 2;
            x *= x;
        }
        return res;
    }
}
