// Problem statement: https://leetcode.com/problems/count-and-say/

public class Solution {
    
    private string Conv(string s) {
        StringBuilder res = new StringBuilder();
        int i = 0;
        for (int j = 1; j < s.Length; j++) {
            if (s[i] != s[j]) {
                res.Append(j-i);
                res.Append(s[i]);
                i = j;
            }
        }
        res.Append(s.Length - i);
        res.Append(s[i]);        
        string ret = res.ToString();
        return ret;
    }
    
    public string CountAndSay(int n) {
        string res = "1";
        for (int i = 1; i < n; i++) {
            res = Conv(res);    
        }
        return res;
    }
}
