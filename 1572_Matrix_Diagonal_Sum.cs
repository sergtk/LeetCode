public class Solution {
    public int DiagonalSum(int[][] mat) {
        int n = mat.Length;
        int ret = 0;
        for (int i = 0; i < n; i++) {
            ret += mat[i][i];
            ret += mat[i][n-i-1];
        }
        if (n % 2 == 1) {
            ret -= mat[n/2][n/2];
        }
        return ret;
    }
}
