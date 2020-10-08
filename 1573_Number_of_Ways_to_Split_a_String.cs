public class Solution {
    const int mod = 1000000000+7;

    public int NumWays(string s) {
        int n = s.Length;
        int n1 = s.Where(v => v == '1').Count();
        if (n1 % 3 != 0)
            return 0;
        if (n1 == 0) {
            long ret1 = ((long)(n-1) * (n-2) / 2) % mod;
            return (int)ret1;
        }
        
        int e1 = -1, b2 = -1, e2 = -1, b3 = -1;
        
        int c = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == '1') {
                c++;
                if (c == n1/3) e1 = i;
                if (c == n1/3 + 1) b2 = i;
                if (c == n1/3*2) e2 = i;
                if (c == n1/3*2 + 1) b3 = i;
            }
        }
        long ret = ((long)(b2 - e1) * (b3 - e2)) % mod;        
        return (int)ret;
    }
}
