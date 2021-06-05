/*
Problem statement: https://leetcode.com/problems/merge-intervals/

Some test cases:
[[1,3],[2,6],[8,10],[15,18]]
[[1,4],[4,5]]
[[1,3],[4,5]]
[[1,3],[3,5],[7,10],[8,9], [10,100]]

*/

public class Solution {
    public int[][] Merge(int[][] intervals) {
        int n = intervals.Length;
        var pnts = new (int, int)[n*2];
        for (int i = 0; i < n; i++) {
            pnts[i*2]   = (intervals[i][0], 0);
            pnts[i*2+1] = (intervals[i][1], 1);
        }
        Array.Sort(pnts);
        
        var res = new List<(int, int)>();
        int cov = 0;
        int start = -1;
        for (int i = 0; i < n*2; i++) {
            if (pnts[i].Item2 == 0) {
                if (cov == 0)
                    start = pnts[i].Item1;
                cov++;
            } else {
                cov--;
                if (cov == 0) {
                    res.Add((start, pnts[i].Item1));
                }
            }
        }
        var ret = res.Select(r => new int[]{r.Item1, r.Item2}).ToArray();
        return ret;    
    }
}
