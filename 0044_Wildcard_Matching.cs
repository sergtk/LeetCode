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
*/

public class Solution {
    public bool IsMatch(string s, string p) {
        int ns = s.Length;
        int np = p.Length;
        bool[,] mem = new bool[ns+1, np+1];
        
        mem[0, 0] = true;
        for (int pi = 1; pi <= np; pi++) {
            mem[0, pi] = p[pi-1] == '*' && mem[0, pi-1];
            //System.Console.WriteLine($"mem[0, {pi}]={mem[0, pi]}");
        }
        for (int si = 1; si <= ns; si++) {
            for (int pi = 1; pi <= np; pi++) {
                bool v;
                if (p[pi-1] == '?') {
                    v = mem[si-1, pi-1];
                } else if (p[pi-1] == '*') {
                    v = mem[si-1, pi] || mem[si, pi-1];
                } else {
                    v = p[pi-1] == s[si-1] && mem[si-1, pi-1];
                }
                mem[si, pi] = v;
            }
        }
        //Console.WriteLine(mem[3, 1]);
        bool ret = mem[ns, np];
        return ret;
    }
}
