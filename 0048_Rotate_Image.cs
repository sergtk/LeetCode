// Problem statement: https://leetcode.com/problems/rotate-image/

public class Solution {
    public void Rotate(int[][] mt) {
        int n = mt.Length;
        int nr1 = (n + 1) / 2;
        int nc1 = n / 2;
        
        for (int r = 0; r < nr1; r++) {
            for (int c = 0; c < nc1; c++) {
                int v = mt[r][c];
                for (int i = 0; i < 4; i++) {
                    (r, c) = (c, n - r - 1);
                    (v, mt[r][c]) = (mt[r][c], v);
                }
            }
        }
    }
}
