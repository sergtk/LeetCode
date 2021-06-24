/*
Problem statement: https://leetcode.com/problems/pascals-triangle/

Some test cases:
[10]
[10, 10]
[10, 10, 10]
[0]
[0, 0]
[0, 0, 0]
[7,1,5,3,6,4]
[7,6,4,3,1]
*/

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var ret = new List<IList<int>>();
        var lastRow = new List<int> {1};
        ret.Add(lastRow);
        for (int r = 2; r <= numRows; r++) {
            var newRow = new List<int>(lastRow.Count + 1);
            newRow.Add(1);
            for (int i = 1; i < r - 1; i++) {
                newRow.Add(lastRow[i-1] + lastRow[i]);
            }
            newRow.Add(1);
            lastRow = newRow;
            ret.Add(lastRow);
        }
        return ret;
    }
}