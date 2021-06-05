/*

Problem statement: https://leetcode.com/problems/spiral-matrix/

Some tests:
[[10]]
[[5,7],[2,3]]
[[1,2,3],[4,5,6],[7,8,9]]
[[1,2,3,4],[5,6,7,8],[9,10,11,12]]
[[11,22,33,44,55],[66,77,88,99,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]

*/

public class Solution {
    public IList<int> SpiralOrder(int[][] mt) {
        int nr = mt.Length;
        int nc = mt[0].Length;
        int r = 0, c = -1;
        var ret = new List<int>(nr*nc);
        int dr = nr;
        int dc = nc+1;
        for (;;) {
            if (--dc == 0) break;
            for (int i = 0; i < dc; i++) {
                c++;
                ret.Add(mt[r][c]);
            }
            if (--dr == 0) break;
            for (int i = 0; i < dr; i++) {
                r++;
                ret.Add(mt[r][c]);
            }
            if (--dc == 0) break;
            for (int i = 0; i < dc; i++) {
                c--;
                ret.Add(mt[r][c]);
            }
            if (--dr == 0) break;
            for (int i = 0; i < dr; i++) {
                r--;
                ret.Add(mt[r][c]);
            }
        }
        return ret;            
    }
}
