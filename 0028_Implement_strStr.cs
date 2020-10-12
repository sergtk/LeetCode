/* Very simple solution, but it is far from optimal */
public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle.Length == 0) return 0;
        int ret = haystack.IndexOf(needle);
        return ret;
    }
}
