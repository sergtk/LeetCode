public class Solution {
    public int MinOperations(string[] logs) {
        int ret = 0;
        foreach (var log in logs) {
            if (log == "./")
                continue;
            if (log == "../")
                ret = Math.Max(ret - 1, 0);
            else
                ret++;
        }
        return ret;
    }
}
