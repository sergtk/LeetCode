/*
Problem statement: https://leetcode.com/problems/unique-paths/
Math combinatorics solution: https://leetcode.com/problems/unique-paths/discuss/22958/Math-solution-O(1)-space
*/

public class Solution {
    public int UniquePaths(int m, int n) {
        var cnt = new int [m, n];
        for (int j = 0; j < n; j++) {
            cnt[0, j] = 1;
        }
        for (int i = 1; i < m; i++) {
            cnt[i, 0] = 1;
            for (int j = 1; j < n; j++) {
                cnt[i, j] = cnt[i-1, j] + cnt[i, j-1];
            }
        }
        return cnt[m-1, n-1];
    }
}
