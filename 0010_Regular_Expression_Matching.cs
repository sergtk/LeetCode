public class Solution {
    public bool IsMatch(string s, string p) {
        s = '@' + s;
        p = '@' + p;
        int ns = s.Length;
        int np = p.Length;
        bool [,] mt = new bool[ns, np];
        mt[0, 0] = true;
        for (int si = 1; si < ns; si++) mt[si, 0] = false;
        
        for (int pi = 1; pi < np; pi++)
        {
            for (int si = 0; si < ns; si++)
            {
                if (char.IsLetter(p[pi])) {
                    if (si == 0)
                    {
                        mt[si, pi] = false;
                        continue;
                    }
                    mt[si, pi] = si > 0 && s[si] == p[pi] && mt[si-1, pi-1];
                    continue;
                }
                if (p[pi] == '.') {
                    if (si == 0) {
                        mt[si, pi] = false;
                        continue;
                    }
                    mt[si, pi] = mt[si-1, pi-1];
                    continue;
                }
                if (p[pi] == '*') {
                    if (mt[si, pi-2]) {
                        mt[si, pi] = true;
                        continue;
                    }
                    if (p[pi-1] == '.' || p[pi-1] == s[si]) {
                        if (si > 0 && mt[si-1, pi]) {
                            mt[si, pi] = true;
                            continue;
                        }
                        mt[si, pi] = false;
                        continue;
                    }
                    mt[si, pi] = false;
                }
            }            
        }
        bool ret = mt[ns - 1, np - 1];
        /*
        Console.WriteLine($"%{s}");
        for (int pi = 0; pi < np; pi++) {
            Console.Write(p[pi]);
            for (int si = 0; si < ns; si++) {
                Console.Write(mt[si, pi] ? 1 : 0);
            }
            Console.WriteLine();
        }
        */
        return ret;
        
    }
}
