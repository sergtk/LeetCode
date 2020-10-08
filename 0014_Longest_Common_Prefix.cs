public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 0) return "";
        for (int pos = 0; ; pos++)
        {
            if (pos >= strs[0].Length) {
                return strs[0];
            }
            for (int si = 1; si < strs.Length; si++) {
                if (pos >= strs[si].Length || strs[0][pos] != strs[si][pos]) {
                    return strs[0].Substring(0, pos);
                }
            }
        }
    }
}
