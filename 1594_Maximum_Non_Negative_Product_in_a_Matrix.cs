public class Solution
{
    public int MaxProductPath(int[][] grid) {        
        int m = grid.Length;
        int n = grid[0].Length;
        
        long[,] pos = new long[m, n];
        long[,] neg = new long[m, n];
        if (grid[0][0] >= 0)
            pos[0, 0] = grid[0][0];
        else
            pos[0, 0] = -1;

        if (grid[0][0] <= 0)
            neg[0, 0] = -grid[0][0];
        else
            neg[0, 0] = -1;
        
        
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                if (r == 0 && c == 0) continue;

                pos[r, c] = neg[r, c] = -1;
                for (int dr = 0; dr <= 1; dr++) {
                    int dc = 1 - dr;
                    int r1 = r - dr;
                    int c1 = c - dc;
                    if (r1 < 0 || c1 < 0) {
                        continue;
                    }
                    if (grid[r][c] >= 0) {
                        long cur = pos[r1, c1] * grid[r][c];
                        if (cur > pos[r, c]) {
                            pos[r, c] = cur;
                        }
                        cur = neg[r1, c1] * grid[r][c];
                        if (cur > neg[r, c]) {
                            neg[r, c] = cur;
                        }
                    }
                        
                    if (grid[r][c] <= 0) {
                        long cur = neg[r1, c1] * -grid[r][c];
                        if (cur > pos[r, c]) {
                            pos[r, c] = cur;
                        }
                        cur = pos[r1, c1] * -grid[r][c];
                        if (cur > neg[r, c]) {
                            neg[r, c] = cur;
                        }
                    }
                }
            }
        }
        /*
        Console.WriteLine("pos:");
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                Console.Write($"{pos[r, c],4}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("neg:");
        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                Console.Write($"{neg[r, c],4}");
            }
            Console.WriteLine();
        }
        */

        long ret = pos[m-1, n-1];
        ret %= 1000000000 + 7;
        return (int)ret;
    }
}
