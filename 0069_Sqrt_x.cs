/*

Problem statement: https://leetcode.com/problems/sqrtx/

Some tests:
0
1
2
3
4
5
6
7
8
9
10
2147483647
2147483646
4
8

*/

public class Solution {
    public int MySqrt(int x) {
        if (x < 2) return x;
        int min = 1, max = x;
        while (min < max) {
            int v = (min + max) / 2;
            if (v > x/v) {
                max = v;
            } else {
                min = v + 1;
            }
        }
        int ret = min-1;
        return ret;
    }
}
