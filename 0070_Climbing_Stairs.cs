// Problem statement: https://leetcode.com/problems/climbing-stairs/

public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 2) return n;
        int fib2 = 1, fib1 = 2;
        for (int i = 3; i <= n; i++) {
            int fib = fib1 + fib2;
            fib2 = fib1;
            fib1 = fib;
        }
        return fib1;
    }
}
