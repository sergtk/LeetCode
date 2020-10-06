public class Solution {
    public int NumSpecial(int[][] mat) {
        int nr = mat.Length;
        int nc = mat[0].Length;
        int ret = 0;
        for (int r = 0; r < nr; r++) {
            for (int c = 0; c < nc; c++) {
                if (mat[r][c] == 0) continue;
                
                bool spec = true;
                
                for (int r1 = 0; r1 < nr; r1++) {
                    if (r == r1) continue;
                    if (mat[r1][c] == 1) {
                        spec = false;
                        break;
                    }
                }
                
                if (!spec) {
                    break;
                }
                
                for (int c1 = 0; c1 < nc; c1++) {
                    if (c1 == c) continue;
                    if (mat[r][c1] == 1) {
                        spec = false;
                        break;
                    }
                }
                
                if (spec) {
                    //Console.WriteLine($"Spec {ret}: ({r}, {c})");
                    ret++;
                }
            }
        }
        return ret;
    }
}
