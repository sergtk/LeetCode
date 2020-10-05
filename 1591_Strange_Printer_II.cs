// 121
// 212
// 121
public class Solution {
    public bool IsPrintable(int[][] targetGrid) {
        int nr = targetGrid.Length;
        int nc = targetGrid[0].Length;
        
        int ncol = targetGrid.Select(r => r.Max()).Max() + 1;
        //Console.WriteLine($"ncol: {ncol}");
        
        int[] minr = new int[ncol];
        Array.Fill(minr, 1000);
        int[] maxr = new int[ncol];
        Array.Fill(maxr, -1);
        int[] minc = new int[ncol];
        Array.Fill(minc, 1000);
        int[] maxc = new int[ncol];
        Array.Fill(maxc, -1);
        
        for (int r = 0; r < nr; r++) {
            for (int c = 0; c < nc; c++) {
                int col = targetGrid[r][c];
                minr[col] = Math.Min(minr[col], r);
                minc[col] = Math.Min(minc[col], c);
                maxr[col] = Math.Max(maxr[col], r);
                maxc[col] = Math.Max(maxc[col], c);
            }
        }
        
        bool [,] cover = new bool[ncol, ncol];
        for (int cl = 0; cl < ncol; cl++) {
            for (int r = minr[cl]; r <= maxr[cl]; r++) {
                for (int c = minc[cl]; c <= maxc[cl]; c++) {
                    cover[targetGrid[r][c], cl] = true;
                }
            }
        }
        bool cont = true;
        bool[] removed = new bool[ncol];
        while (cont) {
            cont = false;
            for (int cl = 0; cl < ncol; cl++) {
                if (removed[cl])
                    continue;
                bool onTop = true;
                for (int clOn = 0; clOn < ncol; clOn++) {
                    if (clOn == cl) continue;
                    if (cover[clOn, cl]) {
                        onTop = false;
                        break;
                    }
                }
                if (onTop) {
                    //Console.WriteLine($"On top color: {cl}");
                    cont = true;
                    removed[cl] = true;
                    for (int clUnder = 0; clUnder < ncol; clUnder++) {
                        cover[cl, clUnder] = false;
                    }
                }
            }
        }
        
        //Console.WriteLine($"removed: " + string.Join(", ", removed));
        
        bool hasNotRemoved = removed.Any(col => !col);
        return !hasNotRemoved;
    }
}