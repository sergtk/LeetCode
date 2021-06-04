/*
Problem statement: https://leetcode.com/problems/wildcard-matching/

Some test cases:
"abcabczzzde"
"*abc???de*"
"aa"
"a"
"aa"
"*"
"cb"
"?a"
"adceb"
"*a*b"
"acdcb"
"a*c?b"
""
""
""
"****"
"sdffsfdsd"
""
"sdffsfdsd"
"*****"
"bbbaab"
"a**?***"
*/

public class Solution {
    public bool IsMatch(string s, string p) {
        int ns = s.Length;
        int np = p.Length;
        bool[] mem1 = new bool[np+1];
        bool[] mem = new bool[np+1];
        
        mem[0] = true;
        for (int pi = 1; pi <= np; pi++) {
            mem[pi] = p[pi-1] == '*' && mem[pi-1];
        }
        for (int si = 1; si <= ns; si++) {
            (mem, mem1) = (mem1, mem);
            mem[0] = false;
            for (int pi = 1; pi <= np; pi++) {
                bool v;
                if (p[pi-1] == '?') {
                    v = mem1[pi-1];
                } else if (p[pi-1] == '*') {
                    v = mem1[pi] || mem[pi-1];
                } else {
                    v = p[pi-1] == s[si-1] && mem1[pi-1];
                }
                mem[pi] = v;
            }
        }
        bool ret = mem[np];
        return ret;
    }
}
