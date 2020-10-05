public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length == 0)
            return "";
        int res = 0;
        int idx = -1;
        for (int c = 0; c < s.Length; c++)
        {
            int d = 0;
            while (c-d >= 0 && c+d < s.Length && s[c-d] == s[c+d])
                d++;
            int cur = d*2 - 1;
            if (cur > res)
            {
                res = cur;
                idx = c - d + 1;
            }
            d = 0;
            while (c-d >= 0 && c+d+1 < s.Length && s[c-d] == s[c+d+1])
                d++;
            cur = d*2;
            if (cur > res)
            {
                res = cur;
                idx = c - d + 1;
            }
        }
        string ret = s.Substring(idx, res);
        return ret;
    }
}