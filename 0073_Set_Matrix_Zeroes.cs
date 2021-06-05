// Problem statement: https://leetcode.com/problems/set-matrix-zeroes/

public class Solution {
    public void SetZeroes(int[][] mat) {
        int nr = mat.Length;
        int nc = mat[0].Length;
        bool zero0 = mat[0].Any(v => v == 0);
        
        for (int r = 1; r < nr; r++) {
            for (int c = 0; c < nc; c++) {
                if (mat[r][c] == 0) mat[0][c] = 0;
            }
        }        
        for (int r = 1; r < nr; r++) {
            bool zero = mat[r].Any(v => v == 0);
            //Console.WriteLine($"r = {r}, zero = {zero}");
            for (int c = 0; c < nc; c++) {
                if (zero || mat[0][c] == 0) mat[r][c] = 0;
            }
        }
        if (zero0) {
            Array.Fill(mat[0], 0);
        }
    }
}
