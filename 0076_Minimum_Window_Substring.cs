/*
Problem statement: https://leetcode.com/problems/minimum-window-substring/

Some test cases:
"ADOBECODEBANC"
"ABC"
"a"
"a"
"a"
"aa"
"AAAZZZ"
"AZAZ"
"a"
"Z"
"aaba"
"aa"

*/

public class Solution {
    
    int[] need;
    int rem;
    int st;
    
    void inc(char c) {
        int i = (int)c - st;
        need[i]--;
        if (need[i] >= 0) {
            rem--;
        }
    }
    
    void dec(char c) {
        int i = (int)c - st;
        need[i]++;
        if (need[i] > 0) {
            rem++;
        }
    }
    
    public string MinWindow(string s, string t) {
        // A(65)..Z(90)a(97)..z(122)

        st = (int)'A';
        int sz = (int)'z' - (int)'A' + 1;
        
        int m = s.Length;
        int n = t.Length;
        
        need = new int[sz];
        foreach (var c in t) need[c - st]++;
        rem = n;
        
        int beg1 = -m-1, end1 = m;
        
        for (int beg = -1, end = 0; end < m; end++) {
            inc(s[end]);
            if (rem == 0)
            {
                while (rem == 0) {
                    beg++;
                    dec(s[beg]);
                }
                inc(s[beg]);
                beg--;
                if (end - beg < end1 - beg1)
                    (end1, beg1) = (end, beg);
            }
        }
        if (beg1 < -1)
            return "";
        var ret = s.Substring(beg1 + 1, end1 - beg1);        
        return ret;
    }
}
